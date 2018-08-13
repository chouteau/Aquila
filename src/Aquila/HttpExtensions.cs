using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Aquila
{
    internal static class HttpExtensions
    {
        internal static NameValueCollection GetParameters(this Uri url)
        {
            if (url == null)
            {
                return new NameValueCollection();
            }
            return url.ParseQueryString();
        }

        internal static string GetParameter(this Uri url, string parameterName)
        {
            var prms = url.GetParameters();
            return prms[parameterName];
        }

        internal static string GetOrSetClientId(this HttpContext ctx, string cookieName, out bool isNewSession)
        {
            var ctxbase = new System.Web.HttpContextWrapper(ctx);
            return GetOrSetClientId(ctxbase, cookieName, out isNewSession);
        }

        internal static string GetOrSetClientId(this HttpContextBase ctx, string cookieName, out bool isNewSession)
        {
            isNewSession = false;
            var ck = ctx.Request.Cookies[cookieName];
            string clientId = null;
            if (ck == null)
            {
                clientId = Guid.NewGuid().ToString();
                ck = new System.Web.HttpCookie(cookieName);
                ck.Expires = DateTime.Now.AddDays(60);
                ck.Value = clientId;

                ctx.Response.AppendCookie(ck);
            }
            else
            {
                clientId = ck.Value;
            }

            return clientId;
        }

        internal static string GetDefaultUserLanguage(this HttpRequestBase request)
        {
            var list = request.UserLanguages;
            if (list != null && list.Count() > 0)
            {
                return list[0];
            }
            return null;
        }
    }
}