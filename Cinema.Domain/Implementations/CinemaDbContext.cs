using System.Linq;
using Cinema.Common.Helpers;
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
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Implementations
{
    public sealed class CinemaDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; } = null!;
        public DbSet<Role>? Roles { get; }
        public DbSet<Chat> Chats { get; } = null!;
        public DbSet<ChatMessage> ChatMessages { get; } = null!;
        public DbSet<MovieShow> MovieShows { get; } = null!;
        public DbSet<News> News { get; } = null!;
        public DbSet<Ticket> Tickets { get; } = null!;
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
        public DbSet<Page> Pages { get; } = null!;

        public static void Main(string[] args)
        {
        }


        private const string DbSection = "DB:",
            DbDataSection = $"{DbSection}Data:",
            SnacksInCinemasTableName = "snacks_in_cinemas",
            ServicesInCinemasTableName = "services_in_cinemas",
            AccessRightsTableName = "access_rights",
            HallsInCinemasTableName = "halls_in_cinemas",
            RolesArray = $"{DbDataSection}Roles",
            CinemaHallsArray = $"{DbDataSection}CinemaHalls",
            MovieFormatsArray = $"{DbDataSection}MovieFormats",
            CinemaHallSeatTypesArray = $"{DbDataSection}CinemaHallSeatTypes",
            PagesArray = $"{DbDataSection}Pages",
            ConnectionString = $"{DbSection}ConnectionString";

        private ConfigurationHelper _configurationHelper;

        public CinemaDbContext(ConfigurationHelper configurationHelper)
        {
            _configurationHelper = configurationHelper;
            //DeleteDb();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(_configurationHelper.GetValue(ConnectionString));
        }

        public void DeleteDb()
        {
            Database.EnsureDeleted();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roles = this._configurationHelper.GetArray<string>(CinemaDbContext.RolesArray)
                .Select(r => new Role() {Name = r}).ToList();
            modelBuilder.Entity<Role>().HasData(roles);
            
            var movieFormats = this._configurationHelper.GetArray<string>(CinemaDbContext.MovieFormatsArray)
                .Select(f => new MovieFormat {Name = f}).ToList();
            modelBuilder.Entity<MovieFormat>().HasData(movieFormats);

            var cinemaHalls = this._configurationHelper.GetArray<CinemaHall>(CinemaDbContext.CinemaHallsArray);
            modelBuilder.Entity<CinemaHall>().HasData(cinemaHalls);
            
            var cinemaHallSeatTypes = this._configurationHelper.GetArray<CinemaHallSeatType>(CinemaHallSeatTypesArray);
            modelBuilder.Entity<CinemaHallSeatType>().HasData(cinemaHallSeatTypes);
            
            var pages = this._configurationHelper.GetArray<Page>(PagesArray);
            modelBuilder.Entity<Page>().HasData(pages);

            modelBuilder.Entity<CinemaAddress>()
                .HasMany(c => c.Snacks)
                .WithMany(s => s.Cinemas)
                .UsingEntity(j => j.ToTable(SnacksInCinemasTableName));

            modelBuilder.Entity<CinemaAddress>()
                .HasMany(c => c.Services)
                .WithMany(s => s.Cinemas)
                .UsingEntity(j => j.ToTable(ServicesInCinemasTableName));

            modelBuilder.Entity<Role>()
                .HasMany(c => c.Pages)
                .WithMany(s => s.Roles)
                .UsingEntity(j => j.ToTable(AccessRightsTableName));

            modelBuilder.Entity<CinemaHall>()
                .HasMany(c => c.Cinemas)
                .WithMany(s => s.Halls)
                .UsingEntity(j => j.ToTable(HallsInCinemasTableName));
        }
    }
}