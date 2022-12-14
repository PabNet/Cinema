using Cinema.Domain.Abstractions;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class CinemaReviewModel : TemplatePageModel
    {
        public void OnGet()
        {
            
        }

        public CinemaReviewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override string Title { get; set; } = "Отзыв о кинотеатре";
    }
}