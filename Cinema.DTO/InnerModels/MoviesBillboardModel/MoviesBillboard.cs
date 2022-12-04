using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.APIModels.MovieModel;
using Cinema.DTO.APIModels.StaffModel;

namespace Cinema.DTO.InnerModels.MoviesBillboardModel
{
    [Table(TableName)]
    public partial class MoviesBillboard
    {
        [Column(MovieInfoColumnName, TypeName = StringColumnType)]
        public string MovieInfo { get; set; } = null!;
        
        [Column(StaffInfoColumnName, TypeName = StringColumnType)]
        public string? StaffInfo { get; set; }
        
        [Column(TrailerColumnName, TypeName = StringColumnType)]
        public string? Trailer { get; set; }
        
        [NotMapped]
        public Movie? Movie { get; set; }
        
        [NotMapped]
        public Staff? Staff { get; set; }
    }
}