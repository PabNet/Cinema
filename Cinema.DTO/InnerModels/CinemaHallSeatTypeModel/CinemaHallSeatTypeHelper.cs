namespace Cinema.DTO.InnerModels.CinemaHallSeatTypeModel
{
    public partial class CinemaHallSeatType : ModelTemplate
    {
        private const string TableName = "cnema_hall_seat_types",
            TypeColumnName = "type",
            MorningPriceColumnName = $"morning_{PriceColumnName}",
            EveningPriceColumnName = $"evening_{PriceColumnName}",
            WeekendPriceColumnName = $"weekend_{PriceColumnName}";
    }
}