using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.VacancyModel;

namespace Cinema.DTO.InnerModels.VacancyResponseModel
{
    [Table(TableName)]
    public partial class VacancyResponse
    {
        [Column(NameColumnName, TypeName = StringColumnType)]
        public string FullName { get; set; } = null!;
        
        [Column(EmailColumnName, TypeName = StringColumnType)]
        public string Email { get; set; } = null!;
        
        [Column(DescriptionColumnName, TypeName = StringColumnType)]
        public string Description { get; set; } = null!;

        public virtual Vacancy Vacancy { get; set; } = null!;
    }
}