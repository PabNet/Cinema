using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.NewsModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    public class NewsModel : TemplatePageModel
    {
        public List<News> News { get; set; }

        public IActionResult OnGetDelete(Guid id)
        {
            var news = this._unitOfWork.NewsRepository.Get(m => m.Id == id).FirstOrDefault();
            this._unitOfWork.NewsRepository.Remove(news!);
            this._unitOfWork.Save();
            
            return RedirectToPage("/News");
        }

        public NewsModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            News = this._unitOfWork.NewsRepository.Get().ToList();
        }

        public override string Title { get; set; } = "Новости";
    }
}