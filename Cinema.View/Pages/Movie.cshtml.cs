using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Cinema.Common.Extensions;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.DTO.APIModels.MovieModel;
using Cinema.DTO.APIModels.StaffModel;
using Cinema.DTO.InnerModels.MoviesBillboardModel;
using Cinema.DTO.InnerModels.MovieShowModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class MovieModel : TemplatePageModel
    {
        public MoviesBillboard? Movie { get; set; }
        public void OnGet(Guid movieId)
        {
            Movie = this._unitOfWork.MoviesBillboardRepository.Get(m=>m.Id == movieId).FirstOrDefault()!;
            if (Movie != null)
            {
                Movie.Movie = Movie.MovieInfo.FromJson<Movie>();
                Movie.Staff = Movie.StaffInfo?.FromJson<List<Staff>>();

                Title = Movie.Movie?.RussianName!;
            }
        }

        public MovieModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override string Title { get; set; } = string.Empty;
    }
}