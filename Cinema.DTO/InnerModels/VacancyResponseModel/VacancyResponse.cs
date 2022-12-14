using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.VacancyModel;

namespace Cinema.DTO.InnerModels.VacancyResponseModel
{
    [Table(TableName)]
    public partial class VacancyResponse
    {
        public virtual Vacancy Vacancy { get; set; } = null!;
    }
}