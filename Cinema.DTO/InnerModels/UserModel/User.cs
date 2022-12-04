using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.DTO.InnerModels.UserModel
{
    [Table(TableName)]
    public partial class User
    {
        [Column(NameColumnName, TypeName = StringColumnType)]
        public string FullName { get; set; } = null!;

        [Column(EmailColumnName, TypeName = StringColumnType)]
        public string Email { get; set; } = null!;
    }
}