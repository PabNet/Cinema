using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.DTO.InnerModels.CinemaSnackModel;
using Cinema.DTO.InnerModels.NewsModel;
using Cinema.DTO.InnerModels.RoleModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class SnackFormModel : TemplatePageModel
    {
        public CinemaSnack? Snack { get; set; }
        public List<CinemaAddress>? Cinemas { get; set; }
        public static Guid? SnackId { get; set; }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                SnackId = id;
                Snack = this._unitOfWork.CinemaSnackRepository.Get(c => c.Id == id).FirstOrDefault();
            }
        }

        public IActionResult OnPost(CinemaSnack snack, string[] cinemas)
        {
            var cinemasObjectArray = this._unitOfWork.CinemaAddressRepository.Get(c=>cinemas.Contains(c.Name)).ToList();
            snack.Cinemas = cinemasObjectArray;
            if(SnackId != null)
            {
                snack.Id = (Guid)SnackId;
                this._unitOfWork.CinemaSnackRepository.Update(snack);
            }
            else
            {
                this._unitOfWork.CinemaSnackRepository.Create(snack);
            }
            
            this._unitOfWork.Save();
            
            return RedirectToPage("/Snacks");
        }

        public SnackFormModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Cinemas = this._unitOfWork.CinemaAddressRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Новая еда";
    }
    
}