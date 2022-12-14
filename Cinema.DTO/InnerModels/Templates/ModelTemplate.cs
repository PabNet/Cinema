using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.DTO.InnerModels
{
    public class ModelTemplate
    {
        public static void Main(string[] args) { }
        
        private const string IdColumnName = "id", IdColumnType = "UNIQUEIDENTIFIER", CreationDateColumnName = "date";

        protected const string NameColumnName = "name",
                               TextColumnName = "text",
                               PriceColumnName = "price",
                               DescriptionColumnName = "description",
                               NumberColumnName = "number",
                               StringColumnType = "NVARCHAR(MAX)",
                               BooleanColumnType = "BIT",
                               DateTimeColumnType = "DATETIME2",
                               NumericColumnType = "INT",
                               FractionalColumnType = "FLOAT";

        [Key, Column(IdColumnName, TypeName = IdColumnType)]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Column(CreationDateColumnName, TypeName = DateTimeColumnType)]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        
    }
}