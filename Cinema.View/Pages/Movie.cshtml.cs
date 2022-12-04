using System;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class MovieModel : TemplatePageModel
    {
        public void OnGet()
        {
            Title = "Джанго";
        }

        public MovieModel(IUnitOfWork unitOfWork, HttpHelper httpHelper) : base(unitOfWork, httpHelper)
        {
        }

        public override string Title { get; set; } = string.Empty;
    }
}