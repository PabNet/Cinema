using System;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaSnackModel;
using Cinema.DTO.InnerModels.VacancyModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class VacancyFormModel : TemplatePageModel
    {
        public Vacancy? Vacancy { get; set; }
        private static Guid? VacancyId { get; set; }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                VacancyId = id;
                Vacancy = this._unitOfWork.VacancyRepository.Get(c => c.Id == id).FirstOrDefault();
            }
        }

        public IActionResult OnPost(Vacancy vacancy)
        {
            if(VacancyId != null)
            {
                vacancy.Id = (Guid)VacancyId;
                this._unitOfWork.VacancyRepository.Update(vacancy);
            }
            else
            {
                this._unitOfWork.VacancyRepository.Create(vacancy);
            }
            
            this._unitOfWork.Save();
            
            return RedirectToPage("/Vacancies");
        }

        public VacancyFormModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override string Title { get; set; } = "Новая вакансия";
    }
}