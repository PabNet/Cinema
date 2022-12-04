using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class RegistrationModel : TemplatePageModel
    {
        public void OnGet()
        {
            
        }

        public RegistrationModel(IUnitOfWork unitOfWork, HttpHelper httpHelper) : base(unitOfWork, httpHelper)
        {
        }

        public override string Title { get; set; } = "Регистрация";
    }
}