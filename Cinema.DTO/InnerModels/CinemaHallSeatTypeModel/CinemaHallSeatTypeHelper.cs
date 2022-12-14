using Cinema.DTO.InnerModels.Templates;

namespace Cinema.DTO.InnerModels.CinemaHallSeatTypeModel
{
    public partial class CinemaHallSeatType : ComponentModelTemplate
    {
        private const string TableName = "cnema_hall_seat_types",
            MorningPriceColumnName = $"morning_{PriceColumnName}",
            EveningPriceColumnName = $"evening_{PriceColumnName}",
            WeekendPriceColumnName = $"weekend_{PriceColumnName}";
    }
}