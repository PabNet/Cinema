namespace Cinema.DTO.InnerModels.TicketModel
{
    public partial class Ticket : ModelTemplate
    {
        private const string TableName = "tickets",
                             KeyColumnName = "key",
                             RowColumnName = "row",
                             SeatColumnName = "seat";
    }
}