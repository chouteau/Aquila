using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

using Aquila;
using Microsoft.AspNetCore.Http.Features;

namespace Aquila.Tests
{
	[TestClass]
	public class PageTrackerTests
	{
		[TestInitialize]
		public void Initialize()
		{
			var services = new ServiceCollection()
								.AddLogging();

			services.AddAquila(config =>
			{
				config.TrackingId = "XXX";
				config.UseBrowserId = true;
			});
			ServiceProvider = services.BuildServiceProvider();
		}

		protected IServiceProvider ServiceProvider { get; set; }

		[TestMethod]
		public async Task Send_Simple_PageView()
		{
			var page = new Uri("http://www.test.com/mypage/?param=abcd&param2=5.8");

			var context = new DefaultHttpContext();
			context.Request.Scheme = page.Scheme;
			context.Request.Host = new HostString(page.Host);
			context.Request.Path = new PathString(page.PathAndQuery);

			var track = ServiceProvider.GetRequiredService<Aquila.PageTrack>();
			await track.SendAsync(context);
		}

		[TestMethod]
		public async Task Send_Simple_PageView_With_BrowserId()
		{
			var page = new Uri("http://www.test.com/mypage/?param=abcd&param2=5.8");

			var context = new DefaultHttpContext();
			var httpConnectionFeature = new HttpConnectionFeature();
			httpConnectionFeature.RemoteIpAddress = System.Net.IPAddress.Parse("1.1.1.1");
			context.Features.Set<IHttpConnectionFeature>(httpConnectionFeature);

			context.Request.Scheme = page.Scheme;
			context.Request.Host = new HostString(page.Host);
			context.Request.Path = new PathString(page.PathAndQuery);
			var accept = new List<Microsoft.Net.Http.Headers.MediaTypeHeaderValue>()
			{
				new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("text/html"),
				new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("text/plain")
			};
			context.Request.GetTypedHeaders().Accept = accept;
			context.Request.Headers["User-Agent"] = "MyUserAgent";

			var track = ServiceProvider.GetRequiredService<Aquila.PageTrack>();
			await track.SendAsync(context);
		}


	}
}
