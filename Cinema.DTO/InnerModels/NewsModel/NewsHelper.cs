using Cinema.DTO.InnerModels.Templates;

namespace Cinema.DTO.InnerModels.NewsModel
{
    public partial class News : ComponentModelTemplate
    {
        private const string TableName = "cinema_news",
                             PosterUrlColumnName = "poster";
    }
}