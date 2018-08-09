using System;
using System.Collections.Specialized;

namespace Aquila
{
    public class GlobalConfiguration
    {
        private static bool m_IsMapperInitialized;

        private static Lazy<AquilaConfiguration> m_Configuration
                = new Lazy<AquilaConfiguration>(() =>
                    {
                        var config = System.Configuration.ConfigurationManager.GetSection("aquila") as NameValueCollection;
                        var settings = new Settings();
                        settings.BindFromConfiguration(config);

                        return new AquilaConfiguration()
                        {
                            Settings = settings,
                            BanishedExtensions = settings.BanishedExtensions.Split(','),
                            HttpClientWrapper = new HttpClientWrapper(),
                            Logger = new DiagnosticsLogger()
                        };
                    }, true);

        public static AquilaConfiguration Configuration
        {
            get
            {
                return m_Configuration.Value;
            }
        }
    }
}