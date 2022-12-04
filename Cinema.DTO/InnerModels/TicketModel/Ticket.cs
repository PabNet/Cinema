using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.DTO.InnerModels.CinemaAddressModel;
using Cinema.DTO.InnerModels.CinemaHallModel;
using Cinema.DTO.InnerModels.CinemaHallSeatModel;
using Cinema.DTO.InnerModels.MovieShowModel;

namespace Cinema.DTO.InnerModels.TicketModel
{
    [Table(TableName)]
    public partial class Ticket
    {
        [Column(KeyColumnName, TypeName = StringColumnType)]
        public string Key { get; set; } = null!;

        public virtual MovieShow? MovieShow { get; set; }

        public virtual CinemaAddress Cinema { get; set; } = null!;

        public virtual CinemaHallSeat Place { get; set; } = null!;
        
        public virtual Account Buyer { get; set; } = null!;
    }
}