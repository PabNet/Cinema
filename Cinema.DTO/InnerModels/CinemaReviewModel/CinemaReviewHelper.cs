using Cinema.DTO.InnerModels.Templates;

namespace Cinema.DTO.InnerModels.CinemaReviewModel
{
    public partial class CinemaReview : ReviewModelTemplate
    {
        private const string TableName = "cinema_reviews",
                             GradeColumnName = "grade";
    }
}