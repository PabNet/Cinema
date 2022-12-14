using System.Collections.Generic;
using System.Linq;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class CinemasInformationModel : TemplatePageModel
    {
        
        public List<CinemaAddress> Cinemas { get; set; }
        public CinemasInformationModel(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public override string Title { get; set; } = "О кинотеатрах";

        public void OnGet()
        {
            Cinemas = this._unitOfWork.CinemaAddressRepository.Get().ToList();
        }
    }
}