using System;
using System.Threading.Tasks;
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

namespace Cinema.Domain.Abstractions
{
    public interface IUnitOfWork : IDisposable
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
        void Save();
    }
}