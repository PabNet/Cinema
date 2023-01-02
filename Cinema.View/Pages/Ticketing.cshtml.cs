using System;
using System.Linq;
using Cinema.Common.Extensions;
using Cinema.Domain.Abstractions;
using Cinema.DTO.APIModels.MovieModel;
using Cinema.DTO.InnerModels.MovieShowModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class TicketingModel : TemplatePageModel
    {
        public MovieShow? MovieShow { get; set; }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                MovieShow = this._unitOfWork.MovieShowRepository.Get(c => c.Id == id).FirstOrDefault();
                MovieShow!.Movie.Movie = MovieShow.Movie.MovieInfo.FromJson<Movie>();
            }
        }

        public TicketingModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override string Title { get; set; } = "Оформление билета";
    }
}