using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.MovieShowModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class MovieShowsModel : TemplatePageModel
    {
        public List<MovieShow> MovieShows { get; set; }

        public IActionResult OnGetDelete(Guid id)
        {
            var movieShow = this._unitOfWork.MovieShowRepository.Get(m => m.Id == id).FirstOrDefault();
            this._unitOfWork.MovieShowRepository.Remove(movieShow!);
            this._unitOfWork.Save();
            
            return RedirectToPage("/MovieShows");
        }

        public MovieShowsModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            MovieShows = this._unitOfWork.MovieShowRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Киносеансы";
    }
}