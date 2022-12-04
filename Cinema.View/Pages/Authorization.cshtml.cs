using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class AuthorizationModel : TemplatePageModel
    {
        public void OnGet()
        {
            
        }

        public override string Title { get; set; } = "Вход";

        public AuthorizationModel(IUnitOfWork unitOfWork, HttpHelper httpHelper) : base(unitOfWork, httpHelper)
        {
        }
    }
}