using System;
using System.Linq;
using System.Security.Claims;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.DTO.InnerModels.CinemaReviewModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class CinemaReviewModel : TemplatePageModel
    {
        private static Guid CinemaId { get; set; }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                CinemaId = id;
            }
        }

        public IActionResult OnPost(CinemaReview review)
        {
            var userLogin = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (userLogin == null)
            {
                return Redirect("/Authorization");
            }
            review.User = _unitOfWork.AccountRepository.Get(a => a.Login == userLogin).FirstOrDefault()!;
            review.Cinema = _unitOfWork.CinemaAddressRepository.Get(m => m.Id == CinemaId).FirstOrDefault();
            this._unitOfWork.CinemaReviewRepository.Create(review);
            this._unitOfWork.Save();
            
            return Redirect("/CinemasInformation");
        }

        public CinemaReviewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override string Title { get; set; } = "Отзыв о кинотеатре";
    }
}