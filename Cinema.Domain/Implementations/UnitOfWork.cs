using System;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.DTO.InnerModels.ChatMessageModel;
using Cinema.DTO.InnerModels.ChatModel;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.DTO.InnerModels.CinemaHallModel;
using Cinema.DTO.InnerModels.CinemaHallSeatModel;
using Cinema.DTO.InnerModels.CinemaHallSeatTypeModel;
using Cinema.DTO.InnerModels.CinemaReviewModel;
using Cinema.DTO.InnerModels.CinemaServiceModel;
using Cinema.DTO.InnerModels.CinemaSnackModel;
using Cinema.DTO.InnerModels.MovieFormatModel;
using Cinema.DTO.InnerModels.MovieReviewModel;
using Cinema.DTO.InnerModels.MoviesBillboardModel;
using Cinema.DTO.InnerModels.MovieShowModel;
using Cinema.DTO.InnerModels.NewsModel;
using Cinema.DTO.InnerModels.RoleModel;
using Cinema.DTO.InnerModels.TicketModel;
using Cinema.DTO.InnerModels.UserModel;
using Cinema.DTO.InnerModels.VacancyModel;
using Cinema.DTO.InnerModels.VacancyResponseModel;

namespace Cinema.Domain.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Account> AccountRepository { get; }
        public IGenericRepository<ChatMessage> ChatMessageRepository { get; }
        public IGenericRepository<Chat> ChatRepository { get; }
        public IGenericRepository<CinemaAddress> CinemaAddressRepository { get; }
        public IGenericRepository<CinemaHall> CinemaHallRepository { get; }
        public IGenericRepository<CinemaHallSeat> CinemaHallSeatRepository { get; }
        public IGenericRepository<CinemaHallSeatType> CinemaHallSeatTypeRepository { get; }
        public IGenericRepository<CinemaReview> CinemaReviewRepository { get; }
        public IGenericRepository<CinemaService> CinemaServiceRepository { get; }
        public IGenericRepository<CinemaSnack> CinemaSnackRepository { get; }
        public IGenericRepository<MovieFormat> MovieFormatRepository { get; }
        public IGenericRepository<MovieReview> MovieReviewRepository { get; }
        public IGenericRepository<MoviesBillboard> MoviesBillboardRepository { get; }
        public IGenericRepository<MovieShow> MovieShowRepository { get; }
        public IGenericRepository<News> NewsRepository { get; }
        public IGenericRepository<Role> RoleRepository { get; }
        public IGenericRepository<Ticket> TicketRepository { get; }
        public IGenericRepository<User> UserRepository { get; }
        public IGenericRepository<Vacancy> VacancyRepository { get; }
        public IGenericRepository<VacancyResponse> VacancyResponseRepository { get; }

        private readonly CinemaDbContext _context;

        private readonly ConfigurationHelper _configurationHelper;

        public UnitOfWork(CinemaDbContext context,
            IGenericRepository<Account> accountRepository,
            IGenericRepository<ChatMessage> chatMessageRepository,
            IGenericRepository<Chat> chatRepository,
            IGenericRepository<CinemaAddress> cinemaAddressRepository,
            IGenericRepository<CinemaHall> cinemaHallRepository,
            IGenericRepository<CinemaHallSeat> cinemaHallSeatRepository,
            IGenericRepository<CinemaHallSeatType> cinemaHallSeatTypeRepository,
            IGenericRepository<CinemaReview> cinemaReviewRepository,
            IGenericRepository<CinemaService> cinemaServiceRepository,
            IGenericRepository<CinemaSnack> cinemaSnackRepository,
            IGenericRepository<MovieFormat> movieFormatRepository,
            IGenericRepository<MovieReview> movieReviewRepository,
            IGenericRepository<MoviesBillboard> moviesBillboardRepository,
            IGenericRepository<MovieShow> movieShowRepository,
            IGenericRepository<News> newsRepository,
            IGenericRepository<Role> roleRepository,
            IGenericRepository<Ticket> ticketRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<Vacancy> vacancyRepository,
            IGenericRepository<VacancyResponse> vacancyResponseRepository,
            ConfigurationHelper configurationHelper)
        {
            _context = context;

            this.AccountRepository = accountRepository;
            this.ChatRepository = chatRepository;
            this.NewsRepository = newsRepository;
            this.RoleRepository = roleRepository;
            this.TicketRepository = ticketRepository;
            this.UserRepository = userRepository;
            this.VacancyRepository = vacancyRepository;
            this.ChatMessageRepository = chatMessageRepository;
            this.CinemaAddressRepository = cinemaAddressRepository;
            this.CinemaHallRepository = cinemaHallRepository;
            this.CinemaReviewRepository = cinemaReviewRepository;
            this.CinemaServiceRepository = cinemaServiceRepository;
            this.CinemaSnackRepository = cinemaSnackRepository;
            this.MovieFormatRepository = movieFormatRepository;
            this.MovieReviewRepository = movieReviewRepository;
            this.CinemaHallSeatTypeRepository = cinemaHallSeatTypeRepository;
            this.CinemaHallSeatRepository = cinemaHallSeatRepository;
            this.VacancyResponseRepository = vacancyResponseRepository;
            this.MovieShowRepository = movieShowRepository;
            this.MoviesBillboardRepository = moviesBillboardRepository;
            this._configurationHelper = configurationHelper;
            
            InitializeData();
        }

        private void InitializeData()
        {
            var roles = this._configurationHelper.GetArray<string>(CinemaDbContext.RolesArray)
                .Select(r => new Role() { Name = r }).ToList();
            foreach (var role in roles)
            {
                this.RoleRepository.CreateOrUpdate(role, r=> r.Name == role.Name);
            }

            var accounts = this._configurationHelper.GetArray<Account>(CinemaDbContext.AccountsArray);
            foreach (var account in accounts)
            {
                account.Role = roles.Find(r => r.Name == account.RoleName)!;
                
                this.AccountRepository.CreateOrUpdate(account, a => a.Login == account.Login);
            }

            var movieFormats = this._configurationHelper.GetArray<string>(CinemaDbContext.MovieFormatsArray)
                .Select(f => new MovieFormat {Type = f}).ToList();
            foreach (var movieFormat in movieFormats)
            {
                this.MovieFormatRepository.CreateOrUpdate(movieFormat, mf=>mf.Type == movieFormat.Type);
            }

            var cinemaHalls = this._configurationHelper.GetArray<CinemaHall>(CinemaDbContext.CinemaHallsArray);
            foreach (var cinemaHall in cinemaHalls)
            {
                this.CinemaHallRepository.CreateOrUpdate(cinemaHall, h=>h.Name == cinemaHall.Name && h.Number == cinemaHall.Number);
            }

            var cinemaHallSeatTypes =
                this._configurationHelper.GetArray<CinemaHallSeatType>(CinemaDbContext.CinemaHallSeatTypesArray);
            foreach (var cinemaHallSeatType in cinemaHallSeatTypes)
            {
                this.CinemaHallSeatTypeRepository.CreateOrUpdate(cinemaHallSeatType, st=>st.Type == cinemaHallSeatType.Type);
            }

            this.Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}