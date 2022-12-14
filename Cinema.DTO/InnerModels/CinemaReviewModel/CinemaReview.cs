using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.DTO.InnerModels.CinemaAddressModel;

namespace Cinema.DTO.InnerModels.CinemaReviewModel
{
    [Table(TableName)]
    public partial class CinemaReview
    {
        [Column(GradeColumnName, TypeName = NumericColumnType)]
        public int? Grade { get; set; }
        
        public virtual CinemaAddress? Cinema { get; set; }

        public virtual Account User { get; set; } = null!;
    }
}