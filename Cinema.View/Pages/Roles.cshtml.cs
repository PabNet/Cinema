using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.RoleModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class RolesModel : TemplatePageModel
    {
        public List<Role> Roles { get; set; }

        public IActionResult OnGetDelete(Guid id)
        {
            var role = this._unitOfWork.RoleRepository.Get(m => m.Id == id).FirstOrDefault();
            this._unitOfWork.RoleRepository.Remove(role!);
            this._unitOfWork.Save();
            
            return RedirectToPage("/Roles");
        }

        public RolesModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Roles = this._unitOfWork.RoleRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Роли";
    }
}