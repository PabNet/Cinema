using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.AccountModel;

namespace Cinema.DTO.InnerModels.VacancyModel
{
    [Table(TableName)]
    public partial class Vacancy
    {
        [Column(NameColumnName, TypeName = StringColumnType)]
        public string Name { get; set; } = null!;

        [Column(DescriptionColumnName, TypeName = StringColumnType)]
        public string Description { get; set; } = null!;

        [Column(StartSalaryColumnName, TypeName = FractionalColumnType)]
        public double StartSalary { get; set; }
        
        public virtual Account? Author { get; set; }
    }
}