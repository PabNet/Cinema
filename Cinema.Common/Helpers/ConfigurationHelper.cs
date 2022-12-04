using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Cinema.Common.Helpers
{
    public class ConfigurationHelper
    {
        private IConfigurationRoot _configuration;

        public ConfigurationHelper(IConfigurationRoot configuration)
        {
            this._configuration = configuration;
        }

        public string GetValue(string key)
        {
            return _configuration[key];
        }

        public List<T> GetArray <T>(string key)
        {
            return _configuration.GetSection(key).Get<List<T>>();
        }
    }
}