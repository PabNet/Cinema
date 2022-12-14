using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Common.Enums;
using Cinema.Common.Extensions;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.DTO.APIModels.MovieModel;
using Cinema.DTO.APIModels.StaffModel;
using Cinema.DTO.InnerModels.CinemaHallModel;
using Cinema.DTO.InnerModels.MoviesBillboardModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class MovieFormModel : TemplatePageModel
    {
        private IApiRepository _apiRepository;
        public MoviesBillboard? Movie { get; set; }
        private static Guid? MovieId { get; set; }
        private static Movie? MovieInfo { get; set; }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                MovieId = id;
                Movie = this._unitOfWork.MoviesBillboardRepository.Get(c => c.Id == id).FirstOrDefault();
                Movie.Movie = MovieInfo = Movie.MovieInfo.FromJson<Movie>();
            }
        }

       

        public IActionResult OnPost(MoviesBillboard movie)
        {
            if(MovieId != null)
            {
                if (MovieInfo?.Id != movie.MovieId)
                {
                    movie.MovieInfo = _apiRepository.ExecuteRequest<Movie>(KinopoiskActions.GetMovieById, movie.MovieId!)
                        .ToJson();
                    movie.StaffInfo = _apiRepository.ExecuteRequest<List<Staff>>(KinopoiskActions.GetStaffByMovieId)
                        .ToJson();
                }
                
                movie.Id = (Guid)MovieId;
                this._unitOfWork.MoviesBillboardRepository.Update(movie);
            }
            else
            {
                movie.MovieInfo = _apiRepository.ExecuteRequest<Movie>(KinopoiskActions.GetMovieById, movie.MovieId!)
                    .ToJson();
                movie.StaffInfo = _apiRepository.ExecuteRequest<List<Staff>>(KinopoiskActions.GetStaffByMovieId, movie.MovieId!)
                    .ToJson();
                
                this._unitOfWork.MoviesBillboardRepository.Create(movie);
            }
            
            this._unitOfWork.Save();
            
            return RedirectToPage("/Movies");
        }

        public MovieFormModel(IApiRepository apiRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._apiRepository = apiRepository;
        }

        public override string Title { get; set; } = "Новое кино";
    }
}