using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.CinemaAddressModel;

namespace Cinema.DTO.InnerModels.CinemaServiceModel
{
    [Table(TableName)]
    public partial class CinemaService
    {
        [Column(NameColumnName, TypeName = StringColumnType)]
        public string Name { get; set; } = null!;

        public virtual List<CinemaAddress>? Cinemas { get; set; }
        
        [Column(PriceColumnName, TypeName = FractionalColumnType)]
        public double? Price { get; set; }
        
        [Column(DescriptionColumnName, TypeName = StringColumnType)]
        public string? Description { get; set; }
    }
}