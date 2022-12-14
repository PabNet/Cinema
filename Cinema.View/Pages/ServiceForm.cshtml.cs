using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.DTO.InnerModels.CinemaServiceModel;
using Cinema.DTO.InnerModels.CinemaSnackModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class ServiceFormModel : TemplatePageModel
    {
        public CinemaService? Service { get; set; }
        public List<CinemaAddress>? Cinemas { get; set; }
        public static Guid? ServiceId { get; set; }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                ServiceId = id;
                Service = this._unitOfWork.CinemaServiceRepository.Get(c => c.Id == id).FirstOrDefault();
            }
        }

        public IActionResult OnPost(CinemaService service)
        {
            if(ServiceId != null)
            {
                service.Id = (Guid)ServiceId;
                this._unitOfWork.CinemaServiceRepository.Update(service);
            }
            else
            {
                this._unitOfWork.CinemaServiceRepository.Create(service);
            }
            
            this._unitOfWork.Save();
            
            return RedirectToPage("/Services");
        }

        public ServiceFormModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Cinemas = this._unitOfWork.CinemaAddressRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Новый сервис";
    }
}