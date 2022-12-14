using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Common.Extensions;
using Cinema.Domain.Abstractions;
using Cinema.DTO.APIModels.MovieModel;
using Cinema.DTO.APIModels.StaffModel;
using Cinema.DTO.InnerModels.MoviesBillboardModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class MoviesModel : TemplatePageModel
    {
        public List<MoviesBillboard> Movies { get; set; }
        
        public IActionResult OnGetDelete(Guid id)
        {
            var movie = this._unitOfWork.MoviesBillboardRepository.Get(m => m.Id == id).FirstOrDefault();
            this._unitOfWork.MoviesBillboardRepository.Remove(movie!);
            this._unitOfWork.Save();
            
            return RedirectToPage("/Movies");
        }

        public MoviesModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Movies = this._unitOfWork.MoviesBillboardRepository.Get().ToList();
            foreach (var movie in Movies)
            {
                movie.Movie = movie.MovieInfo.FromJson<Movie>();
            }
        }

        public override string Title { get; set; } = "Фильмы";
    }
}