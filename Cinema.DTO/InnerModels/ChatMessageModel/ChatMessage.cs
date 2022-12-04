using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.AccountModel;
using Cinema.DTO.InnerModels.ChatModel;

namespace Cinema.DTO.InnerModels.ChatMessageModel
{
    [Table(TableName)]
    public partial class ChatMessage
    {
        [Column(TextColumnName, TypeName = StringColumnType)]
        public string Text { get; set; } = null!;

        public virtual Account Author { get; set; } = null!;

        public virtual Chat Chat { get; set; } = null!;
        
        [Column(SentDateColumnName, TypeName = DateTimeColumnType)]
        public DateTime SentDate { get; set; }
    }
}