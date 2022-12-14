using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.DTO.InnerModels.CinemaHallModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class CinemaHallFormModel : TemplatePageModel
    {
        public CinemaHall? Hall { get; set; }
        public List<CinemaAddress> Cinemas { get; set; }
        public static Guid? HallId { get; set; }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                HallId = id;
                Hall = this._unitOfWork.CinemaHallRepository.Get(c => c.Id == id).FirstOrDefault();
            }
        }

        public IActionResult OnPost(CinemaHall cinemaHall)
        {
            if(HallId != null)
            {
                cinemaHall.Id = (Guid)HallId;
                this._unitOfWork.CinemaHallRepository.Update(cinemaHall);
            }
            else
            {
                this._unitOfWork.CinemaHallRepository.Create(cinemaHall);
            }
            
            this._unitOfWork.Save();
            
            return RedirectToPage("/CinemaHalls");
        }

        public CinemaHallFormModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Cinemas = this._unitOfWork.CinemaAddressRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Новый кинозал";
    }
}