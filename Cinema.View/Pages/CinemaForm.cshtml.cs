using System;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class CinemaFormModel : TemplatePageModel
    {
        public CinemaAddress? Cinema { get; set; }

        public static Guid? CinemaId { get; set; }

        public IActionResult OnPost(CinemaAddress cinema)
        {
            if(CinemaId != null)
            {
                cinema.Id = (Guid)CinemaId;
                this._unitOfWork.CinemaAddressRepository.Update(cinema);
            }
            else
            {
                this._unitOfWork.CinemaAddressRepository.Create(cinema);
            }
            
            this._unitOfWork.Save();
            
            return RedirectToPage("/Cinemas");
        }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                CinemaId = id;
                Cinema = this._unitOfWork.CinemaAddressRepository.Get(c => c.Id == id).FirstOrDefault();
            }
        }

        public CinemaFormModel(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public override string Title { get; set; } = "Новый кинотеатр";
    }
}