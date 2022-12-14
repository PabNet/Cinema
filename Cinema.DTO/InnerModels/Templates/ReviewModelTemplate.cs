using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.DTO.InnerModels.Templates
{
    public class ReviewModelTemplate : ModelTemplate
    {
        [Column(TextColumnName, TypeName = StringColumnType)]
        public string Text { get; set; } = null!;
    }
}