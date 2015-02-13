using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
