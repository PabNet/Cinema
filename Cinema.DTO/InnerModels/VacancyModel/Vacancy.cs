using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.DTO.InnerModels.VacancyResponseModel;

namespace Cinema.DTO.InnerModels.VacancyModel
{
    [Table(TableName)]
    public partial class Vacancy
    {
        [Column(StartSalaryColumnName, TypeName = FractionalColumnType)]
        public double StartSalary { get; set; }
        
        public virtual List<VacancyResponse>? Responses { get; set; }
        
        public virtual Account? Author { get; set; }
    }
}