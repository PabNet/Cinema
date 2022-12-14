using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class AuthorizationModel : TemplatePageModel
    {
        public IActionResult OnPost(Account account)
        {
            var path = default(string);
            var findAccount = _unitOfWork.AccountRepository.Get(a => a.Login == account.Login && a.Password == account.Password).FirstOrDefault();
            if (findAccount != default)
            {
                var r = account.Role;
                if (findAccount.Role.Name == "User")
                {
                    path = "/PersonalOffice";
                }
                else
                {
                    path = "/MovieStudio";
                }
                Authenticate(findAccount);
            }
            else
            {
                path = "/Authorization";
            }

            return RedirectToPage(path);
        }
        
        private void Authenticate(Account user)
        {
            var claims = new List<Claim>
            {
                new (ClaimsIdentity.DefaultNameClaimType, user.Login),
                new (ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name!)
            };
            
            ClaimsIdentity id = new (claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public override string Title { get; set; } = "Вход";

        public AuthorizationModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}