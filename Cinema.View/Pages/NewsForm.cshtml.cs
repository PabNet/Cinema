using System;
using System.Collections.Generic;
using System.Linq;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.DTO.InnerModels.CinemaHallModel;
using Cinema.DTO.InnerModels.NewsModel;
using Cinema.View.Pages.Templates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cinema.View.Pages
{
    [IgnoreAntiforgeryToken]
    public class NewsFormModel : TemplatePageModel
    {
        public News? News { get; set; }
        public static Guid? NewsId { get; set; }

        public void OnGet(Guid id)
        {
            if (id != default)
            {
                NewsId = id;
                News = this._unitOfWork.NewsRepository.Get(c => c.Id == id).FirstOrDefault();
            }
        }

        public IActionResult OnPost(News news)
        {
            if(NewsId != null)
            {
                news.Id = (Guid)NewsId;
                this._unitOfWork.NewsRepository.Update(news);
            }
            else
            {
                this._unitOfWork.NewsRepository.Create(news);
            }
            
            this._unitOfWork.Save();
            
            return RedirectToPage("/News");
        }

        public NewsFormModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override string Title { get; set; } = "Новая новость";
    }
}