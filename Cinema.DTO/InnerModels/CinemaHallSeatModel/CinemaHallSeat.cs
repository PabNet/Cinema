using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.CinemaHallModel;
using Cinema.DTO.InnerModels.CinemaHallSeatTypeModel;

namespace Cinema.DTO.InnerModels.CinemaHallSeatModel
{
    [Table(TableName)]
    public partial class CinemaHallSeat
    {
        [Column(NumberColumnName, TypeName = NumericColumnType)]
        public int Number { get; set; }
        
        [Column(RowNumberColumnName, TypeName = NumericColumnType)]
        public int RowNumber { get; set; }

        public virtual CinemaHallSeatType SeatType { get; set; } = null!;

        public virtual CinemaHall? CinemaHall { get; set; }
    }
}