using System.Collections.Generic;
using System.Linq;
using Cinema.Common.Extensions;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.DTO.APIModels.MovieModel;
using Cinema.DTO.InnerModels.MoviesBillboardModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class BillboardModel : TemplatePageModel
    {

        public List<MoviesBillboard> Billboard { get; set; }
        public BillboardModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override string Title { get; set; } = "Афиша";

        public void OnGet()
        {
            Billboard = this._unitOfWork.MoviesBillboardRepository.Get().ToList();
            foreach (var movie in Billboard)
            {
                movie.Movie = movie.MovieInfo.FromJson<Movie>();
            }
        }
    }
}