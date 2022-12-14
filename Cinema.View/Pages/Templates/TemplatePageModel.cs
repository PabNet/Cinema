using Azure.Core;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages.Templates
{
    public abstract class TemplatePageModel : PageModel
    {
        protected readonly IUnitOfWork _unitOfWork;
        public abstract string Title { get; set; }
        
        public TemplatePageModel(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}