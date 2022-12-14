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
        public virtual List<CinemaAddress>? Cinemas { get; set; }
        
        [Column(PriceColumnName, TypeName = FractionalColumnType)]
        public double? Price { get; set; }
    }
}