using Microsoft.Extensions.Configuration;
using System.IO;

namespace POMFramework
{
    internal class AppSettings
    {
        public string BrowserName { get; set; }
        public string ApplicationURL { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
     

        private static AppSettings instance;
        public static AppSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

                    instance = configuration.Get<AppSettings>();

                }
                return instance;
            }
        }
    }
}
