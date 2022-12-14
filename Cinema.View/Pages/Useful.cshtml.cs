using System.Collections.Generic;
using System.Linq;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;
using Cinema.DTO.InnerModels.NewsModel;
using Cinema.DTO.InnerModels.VacancyModel;
using Cinema.View.Pages.Templates;

namespace Cinema.View.Pages
{
    public class UsefulModel : TemplatePageModel
    {
        
        public List<News> News{ get; set; }
        public List<Vacancy> Vacancies { get; set; }
        
        
        public override string Title { get; set; } = "Полезное";

        public UsefulModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            News = this._unitOfWork.NewsRepository.Get().ToList();
            Vacancies = this._unitOfWork.VacancyRepository.Get().ToList();
        }
        
    }
}