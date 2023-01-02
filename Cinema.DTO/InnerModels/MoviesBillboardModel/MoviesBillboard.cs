using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.APIModels.MovieModel;
using Cinema.DTO.APIModels.StaffModel;
using Cinema.DTO.InnerModels.MovieReviewModel;
using Cinema.DTO.InnerModels.MovieShowModel;

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
        public int? MovieId { get; set; }
        
        [NotMapped]
        public Movie? Movie { get; set; }
        
        [NotMapped]
        public List<Staff>? Staff { get; set; }

        public virtual List<MovieShow>? Shows { get; set; } = new();
        public virtual List<MovieReview>? Reviews { get; set; } = new();
    }
}