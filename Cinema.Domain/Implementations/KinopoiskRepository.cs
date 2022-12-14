using System;
using System.Linq;
using System.Net.Http.Headers;
using Cinema.Common.Enums;
using Cinema.Common.Extensions;
using Cinema.Common.Helpers;
using Cinema.Domain.Abstractions;

namespace Cinema.Domain.Implementations
{
    public class KinopoiskRepository : TemplateRepository, IApiRepository
    {

        private const string KinopoiskSection = "ServiceSettings:Kinopoisk:",
            KinopoiskToken = $"{KinopoiskSection}Token",
            KinopoiskApiUrl = $"{KinopoiskSection}TemplateUrl",
            FilmInformationNewApi = $"{KinopoiskSection}FilmInfoNewApi",
            FilmInformationOldApi = $"{KinopoiskSection}FilmInfoOldApi",
            StaffInformation = $"{KinopoiskSection}StaffInfo",
            KinopoiskTokenHeader = $"{KinopoiskSection}HeaderTokenKey";
        
        private HttpHelper _httpHelper;

        public KinopoiskRepository(HttpHelper httpHelper, ConfigurationHelper configurationHelper) : base(configurationHelper)
        {
            this._httpHelper = httpHelper;
        }

        private void SetKinopoiskHeaders(HttpRequestHeaders headers)
        {
            headers.Add(ConfigurationHelper.GetValue(KinopoiskTokenHeader),
                ConfigurationHelper.GetValue(KinopoiskToken));
        }

        public T ExecuteRequest<T>(Enum command, params object[] parameters)
        {
            var url = default(string);
            switch ((KinopoiskActions) command)
            {
                case KinopoiskActions.GetMovieById:
                {
                    url = $"{ConfigurationHelper.GetValue(KinopoiskApiUrl)}{ConfigurationHelper.GetValue(FilmInformationNewApi)}{parameters.First()}";

                    break;
                }
                case KinopoiskActions.GetStaffByMovieId:
                {
                    url = $"{ConfigurationHelper.GetValue(KinopoiskApiUrl)}{ConfigurationHelper.GetValue(StaffInformation)}?filmId={parameters.First()}";

                    break;
                }
            }

            return _httpHelper.SendGetRequest(url, SetKinopoiskHeaders).Result.FromJson<T>();
        }
    }
}