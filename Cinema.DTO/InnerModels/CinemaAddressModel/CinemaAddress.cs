using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.CinemaServiceModel;
using Cinema.DTO.InnerModels.CinemaSnackModel;

namespace Cinema.DTO.InnerModels.CinemaAddressModel
{
    [Table(TableName)]
    public partial class CinemaAddress
    {
        [Column(NameColumnName, TypeName = StringColumnType)]
        public string? Name { get; set; }

        [Column(AddressColumnName, TypeName = StringColumnType)]
        public string Address { get; set; } = null!;
        
        [Column(MapLinkColumnName, TypeName = StringColumnType)]
        public string? MapLink { get; set; }
        
        public virtual List<CinemaSnack>? Snacks { get; set; }
        
        public virtual List<CinemaService>? Services { get; set; }
    }
}