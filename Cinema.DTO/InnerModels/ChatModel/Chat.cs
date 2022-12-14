using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.AccountModel;

namespace Cinema.DTO.InnerModels.ChatModel
{
    [Table(TableName)]
    public partial class Chat
    {
        public virtual Account? Operator { get; set; }
        
        public virtual Account? Client { get; set; }

        [Column(EndDateColumnName, TypeName = DateTimeColumnType)]
        public DateTime? EndDate { get; set; }
    }
}