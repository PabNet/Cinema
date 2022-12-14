using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Common.Enums;
using Cinema.Common.Helpers;
using Cinema.Common.Helpers.Mail;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.DTO.InnerModels.RoleModel;
using Cinema.DTO.InnerModels.VacancyResponseModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class UserStudioModel : TemplatePageModel
    {
        private IExternalServiceRepository _serviceRepository;
        public List<VacancyResponse> VacancyResponses { get; set; }
        public List<Role> Roles { get; set; } 
        public List<Account> Accounts { get; set; }
        
        public IActionResult OnGetReject(Guid id)
        {
            var vacancyResponse = this._unitOfWork.VacancyResponseRepository.Get(m => m.Id == id).FirstOrDefault();
            _serviceRepository.Execute(PostmanActions.SendRejectMessage, vacancyResponse?.Email!, vacancyResponse?.Name!, vacancyResponse?.Vacancy?.Name!);
            this._unitOfWork.VacancyResponseRepository.Remove(vacancyResponse!);
            this._unitOfWork.Save();
            
            return RedirectToPage("/UserStudio");
        }

        public void OnPost(string login, string role)
        {
            var account = _unitOfWork.AccountRepository.Get(a => a.Login == login).FirstOrDefault();
            var accountRole = _unitOfWork.RoleRepository.Get(r => r.Name == role).FirstOrDefault();
            account!.Role = accountRole!;
            
            _unitOfWork.AccountRepository.Update(account);
            _unitOfWork.Save();
        }

        public UserStudioModel(IExternalServiceRepository serviceRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _serviceRepository = serviceRepository;
            VacancyResponses = this._unitOfWork.VacancyResponseRepository.Get().ToList();
            Roles = this._unitOfWork.RoleRepository.Get().ToList();
            Accounts = this._unitOfWork.AccountRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Пользователи";
    }
}