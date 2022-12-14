using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaSnackModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class SnacksModel : TemplatePageModel
    {
        
        public List<CinemaSnack> Snacks { get; set; }

        public IActionResult OnGetDelete(Guid id)
        {
            var snack = this._unitOfWork.CinemaSnackRepository.Get(m => m.Id == id).FirstOrDefault();
            this._unitOfWork.CinemaSnackRepository.Remove(snack!);
            this._unitOfWork.Save();
            
            return RedirectToPage("/Snacks");
        }

        public SnacksModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Snacks = this._unitOfWork.CinemaSnackRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Еда";
    }
}