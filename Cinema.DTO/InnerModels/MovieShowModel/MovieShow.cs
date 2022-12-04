using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.DTO.InnerModels.MovieFormatModel;
using Cinema.DTO.InnerModels.MoviesBillboardModel;

namespace Cinema.DTO.InnerModels.MovieShowModel
{
    [Table(TableName)]
    public partial class MovieShow
    {
        public virtual MoviesBillboard Movie { get; set; } = null!;

        public virtual CinemaAddress Cinema { get; set; } = null!;
        
        public virtual MovieFormat? Format { get; set; }

        [Column(StartDateColumnName, TypeName = DateTimeColumnType)]
        public DateTime StartDate { get; set; }
    }
}