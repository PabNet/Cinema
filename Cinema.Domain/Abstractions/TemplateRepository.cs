using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Common.Helpers;

namespace Cinema.Domain.Abstractions
{
    public abstract class TemplateRepository
    {
        protected readonly ConfigurationHelper ConfigurationHelper;
        
        public TemplateRepository(ConfigurationHelper configurationHelper)
        {
            this.ConfigurationHelper = configurationHelper;
        }
        
    }
}
