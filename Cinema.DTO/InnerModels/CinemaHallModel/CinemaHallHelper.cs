using Cinema.DTO.InnerModels.Templates;

namespace Cinema.DTO.InnerModels.CinemaHallModel
{
    public partial class CinemaHall : ComponentModelTemplate
    {
        private const string TableName = "cinema_halls",
            RowsColumnName = "rows_count",
            SeatsJsonColumnName = "seats_in_rows";
        
        public class SeatInRow
        {
            public int? Row { get; set; }
            public int? SeatCount { get; set; }
        }
    }
}