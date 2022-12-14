using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.VacancyModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class VacanciesModel : TemplatePageModel
    {
        public List<Vacancy> Vacancies { get; set; }

        public IActionResult OnGetDelete(Guid id)
        {
            var vacancy = this._unitOfWork.VacancyRepository.Get(m => m.Id == id).FirstOrDefault();
            this._unitOfWork.VacancyRepository.Remove(vacancy!);
            this._unitOfWork.Save();
            
            return RedirectToPage("/Vacancies");
        }

        public VacanciesModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Vacancies = _unitOfWork.VacancyRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Вакансии";
    }
}