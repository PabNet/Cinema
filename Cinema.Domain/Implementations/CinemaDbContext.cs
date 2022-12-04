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
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Implementations
{
    public sealed class CinemaDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; } = null!;
        public DbSet<Role> Roles { get; } = null!;
        public DbSet<Chat> Chats { get; } = null!;
        public DbSet<ChatMessage> ChatMessages { get; } = null!;
        public DbSet<MovieShow> MovieShows { get; } = null!;
        public DbSet<News> News { get; } = null!;
        public DbSet<Ticket> Tickets { get; } = null!;
        public DbSet<User> Users { get; } = null!;
        public DbSet<Vacancy> Vacancies { get; } = null!;
        public DbSet<VacancyResponse> VacancyResponses { get; } = null!;
        public DbSet<CinemaReview> CinemaReviews { get; } = null!;
        public DbSet<MovieReview> MovieReviews { get; } = null!;
        public DbSet<CinemaHall> CinemaHalls { get; } = null!;
        public DbSet<CinemaHallSeat> CinemaHallSeats { get; } = null!;
        public DbSet<CinemaHallSeatType> CinemaHallSeatTypes { get; } = null!;
        public DbSet<CinemaAddress> CinemaAddresses { get; } = null!;
        public DbSet<CinemaSnack> CinemaSnacks { get; } = null!;
        public DbSet<CinemaService> CinemaServices { get; } = null!;
        public DbSet<MoviesBillboard> MoviesBillboards { get; } = null!;
        public DbSet<MovieFormat> MovieFormats { get; } = null!;


        private const string DbSection = "DB:",
            DbDataSection = $"{DbSection}Data:",
            SnacksInCinemasTableName = "snacks_in_cinemas",
            ServicesInCinemasTableName = "services_in_cinemas";
        public const string AccountsArray = $"{DbDataSection}Accounts",
                             RolesArray = $"{DbDataSection}Roles",
                             CinemaHallsArray = $"{DbDataSection}CinemaHalls",
                             MovieFormatsArray = $"{DbDataSection}MovieFormats",
                             CinemaHallSeatTypesArray = $"{DbDataSection}CinemaHallSeatTypes",
                             ConnectionString = $"{DbSection}ConnectionString";
        
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
            DeleteDb();
            Database.EnsureCreated();
        }

        public void DeleteDb()
        {
            Database.EnsureDeleted();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CinemaAddress>()
                .HasMany(c => c.Snacks)
                .WithMany(s => s.Cinemas)
                .UsingEntity(j => j.ToTable(SnacksInCinemasTableName));
            
            modelBuilder.Entity<CinemaAddress>()
                .HasMany(c => c.Services)
                .WithMany(s => s.Cinemas)
                .UsingEntity(j => j.ToTable(ServicesInCinemasTableName));
        }
    }
}