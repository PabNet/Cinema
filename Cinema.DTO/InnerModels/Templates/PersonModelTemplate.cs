using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.DTO.InnerModels.Templates
{
    public class PersonModelTemplate : ComponentModelTemplate
    {
        private const string EmailColumnName = "email";
            
        [Column(EmailColumnName, TypeName = StringColumnType)]
        public string? Email { get; set; }
    }
}