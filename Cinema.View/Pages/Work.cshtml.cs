using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class WorkModel : TemplatePageModel
    {
        public override string Title { get; set; } = "Работа";

        public WorkModel(IUnitOfWork unitOfWork, HttpHelper httpHelper) : base(unitOfWork, httpHelper) {}
        
        public void OnGet()
        {
            
        }
    }
}