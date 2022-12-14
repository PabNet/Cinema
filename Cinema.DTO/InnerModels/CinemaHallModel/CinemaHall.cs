using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.CinemaAddressModel;

namespace Cinema.DTO.InnerModels.CinemaHallModel
{
    [Table(TableName)]
    public partial class CinemaHall
    {
        [Column(NumberColumnName, TypeName = NumericColumnType)]
        public int? Number { get; set; }
        
        [Column(RowsColumnName, TypeName = NumericColumnType)]
        public int? RowsCount { get; set; }
        
        [Column(SeatsJsonColumnName, TypeName = StringColumnType)]
        public string? SeatsInRowsJson { get; set; }
        
        [NotMapped]
        public List<SeatInRow>? SeatsInRows { get; set; }
        
        public virtual List<CinemaAddress>? Cinemas { get; set; }
    }
}