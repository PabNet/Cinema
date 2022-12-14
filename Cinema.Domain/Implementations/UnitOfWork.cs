using System;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure;
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
using Cinema.DTO.InnerModels.PageModel;
using Cinema.DTO.InnerModels.RoleModel;
using Cinema.DTO.InnerModels.TicketModel;
using Cinema.DTO.InnerModels.VacancyModel;
using Cinema.DTO.InnerModels.VacancyResponseModel;

namespace Cinema.Domain.Implementations
{
    public class UnitOfWork : TemplateRepository, IUnitOfWork
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
        public IGenericRepository<Vacancy> VacancyRepository { get; }
        public IGenericRepository<VacancyResponse> VacancyResponseRepository { get; }
        public IGenericRepository<Page> PageRepository { get; }
        
        private readonly CinemaDbContext _context;

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
            IGenericRepository<Vacancy> vacancyRepository,
            IGenericRepository<VacancyResponse> vacancyResponseRepository,
            IGenericRepository<Page> pageRepository,
            ConfigurationHelper configurationHelper) : base(configurationHelper)
        {
            _context = context;

            this.AccountRepository = accountRepository;
            this.ChatRepository = chatRepository;
            this.NewsRepository = newsRepository;
            this.RoleRepository = roleRepository;
            this.TicketRepository = ticketRepository;
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
            this.PageRepository = pageRepository;
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