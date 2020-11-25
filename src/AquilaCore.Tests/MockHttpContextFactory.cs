using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Aquila.Tests
{
	public class MockHttpContextFactory
	{
		public static Mock<IHttpContextAccessor> CreateMockHttpContextAccessor()
		{
			var contextAccessor = new Mock<IHttpContextAccessor>();
			var context = new DefaultHttpContext();
			contextAccessor.Setup(i => i.HttpContext).Returns(context);

			var identity = new System.Security.Principal.GenericIdentity("identity");
			var principal = new System.Security.Principal.GenericPrincipal(identity, null);


			// Response
			var response = new Mock<HttpResponse>();
			response.SetupProperty(r => r.StatusCode, 200);
			response.Setup(r => r.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(r => r);
			context.Setup(ctx => ctx.Response).Returns(response.Object);

			// Request
			var request = new Mock<HttpRequest>();
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


			return contextAccessor;
		}

	}
}
