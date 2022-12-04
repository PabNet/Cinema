using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.DTO.InnerModels
{
    public class ModelTemplate
    {
        private const string IdColumnName = "id", IdColumnType = "UNIQUEIDENTIFIER";

        protected const string NameColumnName = "name",
                               TextColumnName = "text",
                               PriceColumnName = "price",
                               DescriptionColumnName = "description",
                               NumberColumnName = "number",
                               StringColumnType = "NVARCHAR(MAX)",
                               BooleanColumnType = "BIT",
                               DateColumnType = "DATE",
                               TimeColumnType = "TIME",
                               DateTimeColumnType = "DATETIME2",
                               NumericColumnType = "INT",
                               FractionalColumnType = "FLOAT";

        [Key, Column(IdColumnName, TypeName = IdColumnType)]
        public Guid Id { get; set; }
    }
}