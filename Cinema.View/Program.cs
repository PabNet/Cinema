using System.IO;
using Cinema.Common.Helpers;
using Cinema.Common.Helpers.Mail;
using Cinema.Domain.Abstractions;
using Cinema.Domain.Implementations;
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
using Cinema.View.Additions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddCors();
services.AddRazorPages();

IConfigurationBuilder confBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(ViewConstant.ConfigurationFilename);
IConfigurationRoot configuration = confBuilder.Build();

services.AddSingleton(c => configuration);
services.AddSingleton<ConfigurationHelper>();
services.AddSingleton<HttpHelper>();
services.AddSingleton<MailHelper>();
services.AddSingleton<JsonHelper>();

services.AddDbContext<CinemaDbContext>();

services.AddScoped<IGenericRepository<Role>, ModelRepository<Role>>();
services.AddScoped<IGenericRepository<Account>, ModelRepository<Account>>();
services.AddScoped<IGenericRepository<Chat>, ModelRepository<Chat>>();
services.AddScoped<IGenericRepository<ChatMessage>, ModelRepository<ChatMessage>>();
services.AddScoped<IGenericRepository<CinemaHall>, ModelRepository<CinemaHall>>();
services.AddScoped<IGenericRepository<CinemaHallSeat>, ModelRepository<CinemaHallSeat>>();
services.AddScoped<IGenericRepository<CinemaHallSeatType>, ModelRepository<CinemaHallSeatType>>();
services.AddScoped<IGenericRepository<CinemaReview>, ModelRepository<CinemaReview>>();
services.AddScoped<IGenericRepository<CinemaService>, ModelRepository<CinemaService>>();
services.AddScoped<IGenericRepository<CinemaSnack>, ModelRepository<CinemaSnack>>();
services.AddScoped<IGenericRepository<MovieFormat>, ModelRepository<MovieFormat>>();
services.AddScoped<IGenericRepository<MovieReview>, ModelRepository<MovieReview>>();
services.AddScoped<IGenericRepository<MoviesBillboard>, ModelRepository<MoviesBillboard>>();
services.AddScoped<IGenericRepository<MovieShow>, ModelRepository<MovieShow>>();
services.AddScoped<IGenericRepository<News>, ModelRepository<News>>();
services.AddScoped<IGenericRepository<Ticket>, ModelRepository<Ticket>>();
services.AddScoped<IGenericRepository<Vacancy>, ModelRepository<Vacancy>>();
services.AddScoped<IGenericRepository<VacancyResponse>, ModelRepository<VacancyResponse>>();
services.AddScoped<IGenericRepository<CinemaAddress>, ModelRepository<CinemaAddress>>();
services.AddScoped<IGenericRepository<Page>, ModelRepository<Page>>();

services.AddScoped<IApiRepository, KinopoiskRepository>();
services.AddScoped<IExternalServiceRepository, PostmanRepository>();

services.AddScoped<IUnitOfWork, UnitOfWork>();

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/");
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();