using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.DTO.InnerModels.Templates
{
    public class ComponentModelTemplate : ModelTemplate
    {
        [Column(NameColumnName, TypeName = StringColumnType)]
        public string? Name { get; set; }
        
        [Column(DescriptionColumnName, TypeName = StringColumnType)]
        public virtual string? Description { get; set; }
    }
}