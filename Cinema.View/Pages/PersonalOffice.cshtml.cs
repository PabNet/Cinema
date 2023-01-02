using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.DTO.InnerModels.RoleModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Page = Cinema.DTO.InnerModels.PageModel.Page;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class PersonalOfficeModel : TemplatePageModel
    {
        public Account? Account { get; set; }
        public string? RoleName { get; set; } = "Не указано";
        public int? TicketsCount { get; set; } = 0;
        public int? CinemaReviewsCount { get; set; } = 0;
        public int? MovieReviewsCount { get; set; } = 0;

        public int? DaysInSite { get; set; } = 0;
        public List<Page>? AccessPages { get; set; }
        
        public PersonalOfficeModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        public IActionResult OnGet()
        {
            var path = default(string);
            var roleName = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultRoleClaimType)!.Value;
            if (roleName != "Administrator")
            {
                var userLogin = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultNameClaimType)!.Value;
                var userRole = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultRoleClaimType)!.Value;
                Account = _unitOfWork.AccountRepository.Get(u => u.Login == userLogin).FirstOrDefault();

                var role = _unitOfWork.RoleRepository.Get(r => r.Name == userRole).FirstOrDefault();
                RoleName = role?.Name;
                TicketsCount = _unitOfWork.TicketRepository.Get(t => t.Buyer.Login == userLogin).Count();
                CinemaReviewsCount = _unitOfWork.CinemaReviewRepository.Get(t => t.User.Login == userLogin).Count();
                MovieReviewsCount = _unitOfWork.MovieReviewRepository.Get(t => t.User.Login == userLogin).Count();
                AccessPages = role?.Pages;
                DaysInSite = ((DateTime.UtcNow - Account?.CreationDate)!).Value.Days;

                return Page();
            }
            else
            {
                path = "/MovieStudio";
            }

            return Redirect(path);
        }

        public IActionResult OnPost(Account account)
        {
            var userLogin = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultNameClaimType)!.Value;
            var user = _unitOfWork.AccountRepository.Get(u => u.Login == userLogin).FirstOrDefault();
            if (user != null)
            {
                user.Name = account.Name;
                user.Email = account.Email;
                
                _unitOfWork.AccountRepository.Update(user);
                _unitOfWork.Save();
            }
            
            return Redirect("/PersonalOffice");
        }

        public override string Title { get; set; } = "Личный кабинет";
    }
}