using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.MovieShowModel;

namespace Cinema.DTO.InnerModels.MovieFormatModel
{
    [Table(TableName)]
    public partial class MovieFormat
    {
        public virtual List<MovieShow>? MovieShows { get; set; }
    }
}