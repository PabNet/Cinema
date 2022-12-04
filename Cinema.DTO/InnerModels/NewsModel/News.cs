using System.ComponentModel.DataAnnotations.Schema;
using Cinema.DTO.InnerModels.AccountModel;

namespace Cinema.DTO.InnerModels.NewsModel
{
    [Table(TableName)]
    public partial class News
    {
        [Column(NameColumnName, TypeName = StringColumnType)]
        public string Name { get; set; } = null!;

        [Column(DescriptionColumnName, TypeName = StringColumnType)]
        public string Description { get; set; } = null!;
        
        [Column(PosterUrlColumnName, TypeName = StringColumnType)]
        public string? PosterUrl { get; set; }
        
        public virtual Account? Author { get; set; }
    }
}