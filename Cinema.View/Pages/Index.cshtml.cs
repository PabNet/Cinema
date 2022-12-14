using Cinema.Common.Helpers;
using Cinema.Common.Helpers.Mail;
using Cinema.Domain.Abstractions;
using Cinema.Domain.Implementations;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class IndexModel : TemplatePageModel
    {
        public IndexModel(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        
        public override string Title { get; set; } = "Главная";

        public void OnGet()
        {
            
        }
    }
}