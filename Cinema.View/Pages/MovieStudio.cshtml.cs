using System.Security.Claims;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class MovieStudioModel : TemplatePageModel
    {
        public void OnGet()
        {
            
        }

        public MovieStudioModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override string Title { get; set; } = "Киномастерская";
    }
}