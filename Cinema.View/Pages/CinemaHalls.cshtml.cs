using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaHallModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class CinemaHallsModel : TemplatePageModel
    {
        public List<CinemaHall> CinemaHalls { get; set; }

        public IActionResult OnGetDelete(Guid id)
        {
            var cinemaHall = this._unitOfWork.CinemaHallRepository.Get(m => m.Id == id).FirstOrDefault();
            this._unitOfWork.CinemaHallRepository.Remove(cinemaHall!);
            this._unitOfWork.Save();
            
            return RedirectToPage("/CinemaHalls");
        }

        public CinemaHallsModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            CinemaHalls = this._unitOfWork.CinemaHallRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Кинозалы";
    }
}