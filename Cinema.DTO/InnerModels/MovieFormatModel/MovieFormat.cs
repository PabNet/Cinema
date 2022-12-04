using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.DTO.InnerModels.MovieFormatModel
{
    [Table(TableName)]
    public partial class MovieFormat
    {
        [Column(TypeColumnName, TypeName = StringColumnType)]
        public string Type { get; set; } = null!;
        
        [Column(DescriptionColumnName, TypeName = StringColumnType)]
        public string? Description { get; set; }
    }
}