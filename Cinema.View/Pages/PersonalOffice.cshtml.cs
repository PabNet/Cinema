using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class PersonalOfficeModel : TemplatePageModel
    {
        public PersonalOfficeModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public void OnGet()
        {
            
        }

        public override string Title { get; set; } = "Личный кабинет";
    }
}