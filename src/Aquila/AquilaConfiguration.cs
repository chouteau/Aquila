using System.Collections.Generic;

namespace Aquila
{
    public class AquilaConfiguration
    {
        public Settings Settings { get; internal set; }
        public IHttpClientWrapper HttpClientWrapper { get; set; }
        public IEnumerable<string> BanishedExtensions { get; internal set; }
        public ILogger Logger { get; set; }
    }
}