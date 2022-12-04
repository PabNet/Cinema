using Azure.Core;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages.Templates
{
    public abstract class TemplatePageModel : PageModel
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly HttpHelper _httpHelper;
        
        public abstract string Title { get; set; }
        
        public TemplatePageModel(IUnitOfWork unitOfWork, HttpHelper httpHelper)
        {
            this._unitOfWork = unitOfWork;
            this._httpHelper = httpHelper;
        }
    }
}