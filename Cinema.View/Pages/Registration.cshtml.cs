using System.Linq;
using System.Runtime.CompilerServices;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class RegistrationModel : TemplatePageModel
    {
        public IActionResult OnPost(string name, string email, string login, string password)
        {
            var path = default(string);
            var accounts = _unitOfWork.AccountRepository.Get().ToList();
            if (accounts.FirstOrDefault(a=>a.Login == login && a.Password == password) == default)
            {
                var role = _unitOfWork.RoleRepository.Get(r =>
                    r.Name == (accounts.Count != default ? "User" : "Administrator")).FirstOrDefault();
                var account = new Account
                {
                    Login = login,
                    Password = password,
                    Email = email,
                    Name =  name,
                    Role = role!
                };
                
                _unitOfWork.AccountRepository.Create(account);
                _unitOfWork.Save();
                
                path = "/Authorization";
            }
            else
            {
                path = "/Registration";
            }
            
            return Redirect(path);
        }

        public RegistrationModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override string Title { get; set; } = "Регистрация";
    }
}