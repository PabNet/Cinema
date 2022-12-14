using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.DTO.InnerModels.MoviesBillboardModel;

namespace Cinema.DTO.InnerModels.MovieReviewModel
{
    [Table(TableName)]
    public partial class MovieReview
    {
        [Column(GradeColumnName, TypeName = NumericColumnType)]
        public int? Grade { get; set; }

        public virtual MoviesBillboard Movie { get; set; } = null!;

        public virtual Account User { get; set; } = null!;
    }
}