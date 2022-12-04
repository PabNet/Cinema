using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cinema.DTO.APIModels.MovieModel
{
    public partial class Movie
    {
        [JsonProperty(IdName)]
        public int? Id { get; set; }

        [JsonProperty(ImdbIdName)]
        public string? ImdbId { get; set; }

        [JsonProperty(RusName)]
        public string? RussianName { get; set; }
        
        [JsonProperty(OrigName)]
        public string? OriginalName { get; set; } 
        
        [JsonProperty(EngName)]
        public string? EnglishName { get; set; } 
        
        [JsonProperty(PosterUrlName)]
        public string? PosterUrl { get; set; } 
        
        [JsonProperty(PosterUrlPreviewName)]
        public string? PosterUrlPreview { get; set; }
        
        [JsonProperty(CoverUrlName)]
        public string? CoverUrl { get; set; } 
        
        [JsonProperty(LogoUrlName)]
        public string? LogoUrl { get; set; } 
        
        [JsonProperty(ReviewsCountName)]
        public int? ReviewsCount { get; set; }
        
        [JsonProperty(RatingGoodReviewName)]
        public double? RatingGoodReview { get; set; }
        
        [JsonProperty(RatingGoodReviewVoteCountName)]
        public int? RatingGoodReviewVoteCount { get; set; }
        
        [JsonProperty(RatingName)]
        public double? Rating{ get; set; }
        
        [JsonProperty(RatingVoteCountName)]
        public int? RatingVoteCount { get; set; }
        
        [JsonProperty(RatingImdbName)]
        public double? RatingImdb { get; set; }
        
        [JsonProperty(RatingImdbVoteCountName)]
        public int? RatingImdbVoteCount { get; set; }
        
        [JsonProperty(RatingFilmCriticsName)]
        public double? RatingFilmCritics { get; set; }
        
        [JsonProperty(RatingFilmCriticsVoteCountName)]
        public int? RatingFilmCriticsVoteCount { get; set; }
        
        [JsonProperty(RatingRussianCriticsName)]
        public double? RatingRussianCritics { get; set; }
        
        [JsonProperty(RatingRussianCriticsVoteCountName)]
        public int? RatingRussianCriticsVoteCount { get; set; }
        
        [JsonProperty(WebUrlName)]
        public string? WebUrl { get; set; }
        
        [JsonProperty(CreationYearName)]
        public int? CreationYear { get; set; }
        
        [JsonProperty(FilmLengthName)]
        public int? FilmLength { get; set; }
        
        [JsonProperty(FilmSloganName)]
        public string? Slogan { get; set; }
        
        [JsonProperty(FilmDescriptionName)]
        public string? Description { get; set; }
        
        [JsonProperty(FilmShortDescriptionName)]
        public string? ShortDescription { get; set; } 
        
        [JsonProperty(EditorAnnotationName)]
        public string? EditorAnnotation { get; set; } 
        
        [JsonProperty(IsTicketsAvailableName)]
        public bool? IsTicketAvailable { get; set; }
        
        [JsonProperty(ProductionStatusName)]
        public string? ProductionStatus { get; set; }
        
        [JsonProperty(TypeName)]
        public string? Type { get; set; }
        
        [JsonProperty(RatingMpaName)]
        public string? RatingMpa { get; set; }
        
        [JsonProperty(RatingAgeLimitsName)]
        public string? RatingAgeLimits { get; set; }
        
        [JsonProperty(HasImaxName)]
        public bool? HasImax { get; set; }
        
        [JsonProperty(Has3DName)]
        public bool? Has3D { get; set; }
        
        [JsonProperty(LastSyncName)]
        public string? LastSync { get; set; }
        
        [JsonProperty(StartYearName)]
        public int? StartYear { get; set; }
        
        [JsonProperty(EndYearName)]
        public int? EndYear { get; set; }
        
        [JsonProperty(CompletedName)]
        public bool? Completed { get; set; }
        
        [JsonProperty(ShortFilmName)]
        public bool? ShortFilm { get; set; }
        
        [JsonProperty(SerialName)]
        public bool? Serial { get; set; }

        [JsonProperty(CountriesName)]
        public List<Country>? Countries { get; set; }
        
        [JsonProperty(GenresName)]
        public List<Genre>? Genres { get; set; } 

        public class Country
        {
            [JsonProperty(Movie.CountryName)]
            public string? CountryName { get; set; }
        }

        public class Genre
        {
            [JsonProperty(Movie.GenreName)]
            public string? GenreName { get; set; }
        }
    }
}