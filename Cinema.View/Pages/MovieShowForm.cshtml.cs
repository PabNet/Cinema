using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.DTO.InnerModels.CinemaHallModel;
using Cinema.DTO.InnerModels.MovieFormatModel;
using Cinema.DTO.InnerModels.MoviesBillboardModel;
using Cinema.DTO.InnerModels.MovieShowModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class MovieShowFormModel : TemplatePageModel
    {
        public List<MoviesBillboard> MoviesBillboards { get; set; }
        public List<MovieFormat> MovieFormats { get; set; }
        public List<CinemaAddress> Cinemas { get; set; }
        public List<CinemaHall> Halls { get; set; }
        
        public MovieShow? MovieShow { get; set; }
        private static Guid? MovieShowId { get; set; }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                MovieShowId = id;
                MovieShow = this._unitOfWork.MovieShowRepository.Get(c => c.Id == id).FirstOrDefault();
            }
        }

        public IActionResult OnPost(MovieShow movieShow)
        {
            if(MovieShowId != null)
            {
                movieShow.Id = (Guid)MovieShowId;
                this._unitOfWork.MovieShowRepository.Update(movieShow);
            }
            else
            {
                this._unitOfWork.MovieShowRepository.Create(movieShow);
            }
            
            return RedirectToPage("/MovieShows");
        }
        

        public MovieShowFormModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Halls = this._unitOfWork.CinemaHallRepository.Get().ToList();
            Cinemas = this._unitOfWork.CinemaAddressRepository.Get().ToList();
            MovieFormats = this._unitOfWork.MovieFormatRepository.Get().ToList();
            MoviesBillboards = this._unitOfWork.MoviesBillboardRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Новый киносеанс";
    }
}