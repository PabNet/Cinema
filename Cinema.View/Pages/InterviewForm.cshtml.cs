using System;
using System.Linq;
using Cinema.Common.Enums;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaSnackModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class InterviewFormModel : TemplatePageModel
    {
        private IExternalServiceRepository _serviceRepository;
        
        public static Guid? VacancyResponseId { get; set; }

        public void OnGet(Guid vacancyResponseId)
        {
            VacancyResponseId = vacancyResponseId;
        }
        
        public IActionResult OnPost(string address, string number, string date, string time)
        {
            if (VacancyResponseId != null)
            {
                var vacancyResponse = _unitOfWork.VacancyResponseRepository.Get(v => v.Id == VacancyResponseId)
                    .FirstOrDefault();
                _serviceRepository.Execute(PostmanActions.SendInviteMessage, 
                    vacancyResponse?.Email!, 
                    vacancyResponse?.Name!,
                    vacancyResponse?.Vacancy?.Name!,
                    address, date, time, number);
                
                this._unitOfWork.VacancyResponseRepository.Remove(vacancyResponse!);
                this._unitOfWork.Save();
            }
            
            return RedirectToPage("/UserStudio");
        }
        
        public InterviewFormModel(IExternalServiceRepository serviceRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _serviceRepository = serviceRepository;
        }

        public override string Title { get; set; } = "Интервью";
    }
}