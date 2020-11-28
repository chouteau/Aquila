using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class BrowserIdClientIdGenerator : IClientIdGenerator
	{
		public BrowserIdClientIdGenerator(IMemoryCache cache)
		{
			this.Cache = cache;
		}

		public string Name => "BrowserId";
		public IMemoryCache Cache { get;  }

		public ClientInfo GetClientId(HttpContext httpContext)
		{
			var browserId = new BrowserInfo();

			browserId.Ip = httpContext.GetUserHostAddress();
			browserId.UserAgent = httpContext.GetUserAgent();
			var typedHeaders = httpContext.Request.GetTypedHeaders();
			browserId.Accept = string.Join('|', typedHeaders.Accept);
			browserId.AcceptEncoding = string.Join('|', typedHeaders.AcceptEncoding);
			browserId.AcceptLanguage = string.Join('|', typedHeaders.AcceptLanguage);
			browserId.AcceptCharset = string.Join('|', typedHeaders.AcceptCharset);
			browserId.UpgradeInsecureRequest = $"{httpContext.Request.Headers["upgrate-insecure-request"]}";

			var result = new ClientInfo();
			result.Id = browserId.GetSHA256();

			var cacheKey = $"bid:{result.Id}";

			Cache.TryGetValue(cacheKey, out object exist);
			if (exist == null)
			{
				result.IsNewSession = true;
				Cache.Set(cacheKey, true, new MemoryCacheEntryOptions()
				{
					SlidingExpiration = TimeSpan.FromMinutes(30)
				});
			}

			return result;
		}
	}
}
