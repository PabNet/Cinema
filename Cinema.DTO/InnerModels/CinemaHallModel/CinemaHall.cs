using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.CinemaAddressModel;

namespace Cinema.DTO.InnerModels.CinemaHallModel
{
    [Table(TableName)]
    public partial class CinemaHall
    {
        [Column(NameColumnName, TypeName = StringColumnType)]
        public string? Name { get; set; }
        
        [Column(NumberColumnName, TypeName = NumericColumnType)]
        public int? Number { get; set; }
        
        public virtual CinemaAddress? CinemaAddress { get; set; }
    }
}