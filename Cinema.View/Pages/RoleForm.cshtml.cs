using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.RoleModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Page = Cinema.DTO.InnerModels.PageModel.Page;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class RoleFormModel : TemplatePageModel
    {
        
        public Role? Role { get; set; }
        
        public List<Page>? Pages { get; set; }
        public static Guid? RoleId { get; set; }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                RoleId = id;
                Role = this._unitOfWork.RoleRepository.Get(c => c.Id == id).FirstOrDefault();
            }
        }

        public IActionResult OnPost(Role role)
        {
            if(RoleId != null)
            {
                role.Id = (Guid)RoleId;
                this._unitOfWork.RoleRepository.Update(role);
            }
            else
            {
                this._unitOfWork.RoleRepository.Create(role);
            }
            
            this._unitOfWork.Save();
            
            return RedirectToPage("/Roles");
        }

        public RoleFormModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Pages = this._unitOfWork.PageRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Новая роль";
    }
}