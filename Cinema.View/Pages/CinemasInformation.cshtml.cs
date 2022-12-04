using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class CinemasInformationModel : TemplatePageModel
    {
        public CinemasInformationModel(IUnitOfWork unitOfWork, HttpHelper httpHelper) : base(unitOfWork, httpHelper)
        {
        }
        public override string Title { get; set; } = "О кинотеатрах";
        
        
        public void OnGet()
        {
            
        }
    }
}