using System;
using System.Linq;
using System.Security.Claims;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.MovieReviewModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class MovieReviewModel : TemplatePageModel
    {
        private static Guid MovieId { get; set; }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                MovieId = id;
            }
        }

        public IActionResult OnPost(MovieReview movieReview)
        {
            var userLogin = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (userLogin == null)
            {
                return Redirect("/Authorization");
            }
            movieReview.User = _unitOfWork.AccountRepository.Get(a => a.Login == userLogin).FirstOrDefault()!;
            movieReview.Movie = _unitOfWork.MoviesBillboardRepository.Get(m => m.Id == MovieId).FirstOrDefault();
            this._unitOfWork.MovieReviewRepository.Create(movieReview);
            this._unitOfWork.Save();
            
            return Redirect("/Billboard");
        }

        public MovieReviewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override string Title { get; set; } = "Отзыв о фильме";
    }
}