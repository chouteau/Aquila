using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class ClientIdCookieGenerator : IClientIdGenerator
	{
		public ClientIdCookieGenerator(Settings settings)
		{
			this.Settings = settings;
		}

		protected Settings Settings { get; }
		public string Name => "Cookie";

		public ClientInfo GetClientId(HttpContext httpContext)
		{
			var result = new ClientInfo();
			var ck = httpContext.Request.Cookies[Settings.CookieName];
			if (ck == null)
			{
				var cko = new CookieOptions();
				cko.Expires = DateTime.Now.AddDays(60);
				cko.SameSite = SameSiteMode.None;

				httpContext.Response.Cookies.Append(Settings.CookieName, result.Id, cko);
				result.IsNewSession = true;
			}
			else
			{
				result.Id = ck;
				result.IsNewSession = false;
			}

			return result;
		}
	}
}
