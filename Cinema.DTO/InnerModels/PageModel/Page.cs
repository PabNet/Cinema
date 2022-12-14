using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.RoleModel;

namespace Cinema.DTO.InnerModels.PageModel
{
    [Table(TableName)]
    public partial class Page
    {
        public virtual List<Role>? Roles { get; set; }

        [NotMapped]
        public override string? Description { get; set; }
    }
}