using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Rain
{
    public sealed class Config
    {
        private static readonly Config _globals = new Config();
        public string HeaderImageUrl { get; set; }
        public string ApiUrl { get; set; }
        public string ApiTitle { get; set; }
        public string ApiVersion { get; set; }
        public string SourceUrl { get; set; }
        public string CompanyName { get; set; }

        static Config() { }

        /// <summary>
        /// Sets default values and loads configuration from
        /// App/Web.config file.
        /// </summary>
        private Config() {

            // Read all configuration from app/web.config
            this.HeaderImageUrl = ConfigurationManager.AppSettings["Rain.HeaderImageUrl"];
            this.ApiUrl = ConfigurationManager.AppSettings["Rain.ApiUrl"];
            this.ApiTitle = ConfigurationManager.AppSettings["Rain.ApiTitle"];
            this.ApiVersion = ConfigurationManager.AppSettings["Rain.ApiVersion"];
            this.SourceUrl = ConfigurationManager.AppSettings["Rain.SourceUrl"];
            this.CompanyName = ConfigurationManager.AppSettings["Rain.CompanyName"];
            
            // Check for null/empty values and set default values if they are missing.
            if (string.IsNullOrEmpty(this.HeaderImageUrl))
                this.HeaderImageUrl = "img/logo.png";

            if (string.IsNullOrEmpty(this.ApiUrl))
                this.ApiUrl = "http://www.martin-brennan.github.io/rain";

            if (string.IsNullOrEmpty(this.ApiTitle))
                this.ApiTitle = "Rain API Documentation";

            if (string.IsNullOrEmpty(this.ApiVersion))
                this.ApiVersion = "0.0.1";

            if (string.IsNullOrEmpty(this.SourceUrl))
                this.SourceUrl = "https://github.com/martin-brennan/rain";

            if (string.IsNullOrEmpty(this.CompanyName))
                this.CompanyName = "Rain";
        }

        public static Config Globals
        {
            get { return _globals; }
        }
    }
}
