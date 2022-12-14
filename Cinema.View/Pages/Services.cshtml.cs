using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaServiceModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class ServicesModel : TemplatePageModel
    {
        public List<CinemaService> Services { get; set; }

        public IActionResult OnGetDelete(Guid id)
        {
            var service = this._unitOfWork.CinemaServiceRepository.Get(m => m.Id == id).FirstOrDefault();
            this._unitOfWork.CinemaServiceRepository.Remove(service!);
            this._unitOfWork.Save();
            
            return RedirectToPage("/Services");
        }

        public ServicesModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Services = this._unitOfWork.CinemaServiceRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Сервисы";
    }
}