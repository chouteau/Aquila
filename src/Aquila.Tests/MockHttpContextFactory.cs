using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Moq;

namespace Aquila.Tests
{
	public class MockHttpContextFactory
	{
		public Mock<HttpContextBase> CreateMockHttpContext()
		{
			var context = new Mock<HttpContextBase>();
			var cookies = new HttpCookieCollection();
			var identity = new System.Security.Principal.GenericIdentity("identity");
			var principal = new System.Security.Principal.GenericPrincipal(identity, null);


			// Response
			var response = new Mock<HttpResponseBase>();
			var cachePolicy = new Mock<HttpCachePolicyBase>();
			response.SetupProperty(r => r.StatusCode, 200);
			response.Setup(r => r.Cache).Returns(cachePolicy.Object);
			response.Setup(r => r.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(r => r);
			response.Setup(r => r.Cookies).Returns(cookies);
			context.Setup(ctx => ctx.Response).Returns(response.Object);

			// Request
			var request = new Mock<HttpRequestBase>();
			var visitorId = Guid.NewGuid().ToString();
			request.Setup(r => r.Cookies).Returns(cookies);
			request.Setup(r => r.Url).Returns(new Uri("http://www.test.com"));
			request.Setup(r => r.Headers).Returns(new System.Collections.Specialized.NameValueCollection());
			request.Setup(r => r.RequestContext).Returns(new System.Web.Routing.RequestContext(context.Object, new System.Web.Routing.RouteData()));
			request.SetupGet(x => x.PhysicalApplicationPath).Returns("/");
			request.Setup(r => r.UserHostAddress).Returns("127.0.0.1");
			request.Setup(r => r.UserAgent).Returns("Mozilla/5.0 (Windows NT 6.1; WOW64; rv:26.0) Gecko/20100101 Firefox/26.0");
			request.SetupGet(r => r.QueryString).Returns(new System.Collections.Specialized.NameValueCollection());
			request.SetupGet(r => r.Form).Returns(new System.Collections.Specialized.NameValueCollection());
			request.SetupGet(r => r.PathInfo).Returns(string.Empty);
			request.SetupGet(r => r.AppRelativeCurrentExecutionFilePath).Returns("~/");
			context.Setup(ctx => ctx.Request).Returns(request.Object);

			// Sessions
			var session = new Mock<HttpSessionStateBase>();
			context.Setup(ctx => ctx.Session).Returns(session.Object);

			// Server
			var server = new Mock<HttpServerUtilityBase>();
			server.Setup(s => s.MapPath(It.IsAny<string>())).Returns<string>(r =>
			{
				if (r.Equals("/bin", StringComparison.InvariantCultureIgnoreCase))
				{
					r = string.Empty;
				}
				var path = this.GetType().Assembly.Location;
				var fileName = System.IO.Path.GetFileName(path);
				path = path.Replace(fileName, string.Empty);
				r = r.Trim('/').Trim('\\');
				path = System.IO.Path.Combine(path, r);
				return path;
			});
			context.Setup(ctx => ctx.Server).Returns(server.Object);

			// Principal
			context.Setup(ctx => ctx.User).Returns(principal);

			// Items
			context.Setup(ctx => ctx.Items).Returns(new Dictionary<string, object>());

			return context;
		}

	}
}
