using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.AccountModel;

namespace Cinema.DTO.InnerModels.NewsModel
{
    [Table(TableName)]
    public partial class News
    {
        [Column(PosterUrlColumnName, TypeName = StringColumnType)]
        public string? PosterUrl { get; set; }
        
        public virtual Account? Author { get; set; }
    }
}