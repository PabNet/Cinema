using Newtonsoft.Json;

namespace Cinema.DTO.APIModels.StaffModel
{
    public partial class Staff
    {
        [JsonProperty(IdName)]
        public int Id { get; set; }

        [JsonProperty(RusName)]
        public string? RussianName { get; set; }

        [JsonProperty(EngName)]
        public string? EnglishName { get; set; }

        [JsonProperty(DescriptionName)]
        public string? Description { get; set; }

        [JsonProperty(PosterUrlName)]
        public string? PosterUrl { get; set; }

        [JsonProperty(ProfessionTextName)]
        public string? ProfessionText { get; set; }

        [JsonProperty(ProfessionKeyName)]
        public string? ProfessionKey { get; set; } 
    }
}