using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.DTO.InnerModels.CinemaHallSeatTypeModel
{
    [Table(TableName)]
    public partial class CinemaHallSeatType
    {
        [Column(TypeColumnName, TypeName = StringColumnType)]
        public string Type { get; set; } = null!;
        
        [Column(MorningPriceColumnName, TypeName = FractionalColumnType)]
        public double MorningPrice { get; set; }
        
        [Column(EveningPriceColumnName, TypeName = FractionalColumnType)]
        public double EveningPrice { get; set; }
        
        [Column(WeekendPriceColumnName, TypeName = FractionalColumnType)]
        public double WeekendPrice { get; set; }
    }
}