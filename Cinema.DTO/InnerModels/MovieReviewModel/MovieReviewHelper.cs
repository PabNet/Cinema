using Cinema.DTO.InnerModels.Templates;

namespace Cinema.DTO.InnerModels.MovieReviewModel
{
    public partial class MovieReview : ReviewModelTemplate
    {
        private const string TableName = "movie_reviews",
            GradeColumnName = "grade";
    }
}