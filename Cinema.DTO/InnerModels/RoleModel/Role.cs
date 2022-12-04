using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.DTO.InnerModels.RoleModel
{
    [Table(TableName)]
    public partial class Role
    {
        [Column(NameColumnName, TypeName = StringColumnType)]
        public string Name { get; set; } = null!;
    }
}