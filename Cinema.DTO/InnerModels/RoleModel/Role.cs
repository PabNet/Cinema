using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.DTO.InnerModels.PageModel;

namespace Cinema.DTO.InnerModels.RoleModel
{
    [Table(TableName)]
    public partial class Role
    {
        public virtual List<Page>? Pages { get; set; }
        
        public virtual List<Account>? Accounts { get; set; }
    }
}