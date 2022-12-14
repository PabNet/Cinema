using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.RoleModel;

namespace Cinema.DTO.InnerModels.AccountModel
{
    [Table(TableName)]
    public partial class Account
    {
        [Column(LoginColumnName, TypeName = StringColumnType)]
        public string Login { get; set; } = null!;

        [Column(PasswordColumnName, TypeName = StringColumnType)]
        public string Password { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
        [NotMapped]
        public string? RoleName { get; set; }

        [NotMapped]
        public override string? Description { get; set; }
    }
}