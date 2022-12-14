using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class CinemasModel : TemplatePageModel
    {
        public List<CinemaAddress> Cinemas { get; set; }

        public IActionResult OnGetDelete(Guid id)
        {
            var cinema = this._unitOfWork.CinemaAddressRepository.Get(c=>c.Id == id).FirstOrDefault();
            this._unitOfWork.CinemaAddressRepository.Remove(cinema!);
            this._unitOfWork.Save();
            
            return RedirectToPage("/Cinemas");
        }

        public CinemasModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Cinemas = this._unitOfWork.CinemaAddressRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Кинотеатры";
    }
}