using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;

using Aquila;
using Microsoft.AspNetCore.Http;

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


	}
}
