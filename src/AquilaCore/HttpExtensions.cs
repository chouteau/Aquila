using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Aquila
{
	internal static class HttpExtensions
	{
		internal static (string clientId, bool newsession) GetOrSetClientId(this HttpContext ctx, string cookieName)
		{
			var isNewSession = false;
			var ck = ctx.Request.Cookies[cookieName];
			string clientId = null;
			if (ck == null)
			{
				clientId = Guid.NewGuid().ToString();
				var cko = new CookieOptions();
				cko.Expires = DateTime.Now.AddDays(60);
				cko.SameSite = SameSiteMode.None;
				// cko.Secure = true;

				ctx.Response.Cookies.Append(cookieName, clientId, cko);
				isNewSession = true;
			}
			else
			{
				clientId = ck;
			}

			return (clientId, isNewSession);
		}

		internal static string GetDefaultUserLanguage(this HttpContext httpContext)
		{
			var list = httpContext.Request.GetTypedHeaders().AcceptLanguage;
			if (list != null && list.Count() > 0)
			{
				return list.First().Value.Value;
			}
			return null;
		}

		internal static string GetUserHostAddress(this HttpContext httpContext)
		{
			return $"{httpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress}";
		}

		internal static string GetUserAgent(this HttpContext httpContext)
		{
			return httpContext.Request.Headers["User-Agent"].FirstOrDefault();
		}

		internal static Uri GetAbsoluteUri(this HttpContext httpContext)
		{
			var request = httpContext.Request;
			var uriBuilder = new UriBuilder();
			uriBuilder.Scheme = request.Scheme;
			uriBuilder.Host = request.Host.Host;
			uriBuilder.Path = request.Path.ToString();
			uriBuilder.Query = request.QueryString.ToString();
			return uriBuilder.Uri;
		}

		internal static string GetParameter(this HttpContext httpContext, string key)
		{
			if (!httpContext.Request.QueryString.HasValue)
			{
				return null;
			}

			if (httpContext.Request.Query.Keys.Any(i => i.Equals(key, StringComparison.InvariantCultureIgnoreCase)))
			{
				return httpContext.Request.Query[key];
			}
			return null;
		}
	}
}
