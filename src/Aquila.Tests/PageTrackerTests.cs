using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NFluent;

namespace Aquila.Tests
{
	[TestClass]
	public class PageTrackerTests
	{
		[TestInitialize]
		public void Initialize()
		{
			MockHttpContextFactory = new MockHttpContextFactory();
		}

		protected MockHttpContextFactory MockHttpContextFactory { get; private set; }

		[TestMethod]
		public async Task Send_Simple_PageView()
		{
			var page = "http://www.test.com/mypage/?param=abcd&param2=5.8";
			var mq = MockHttpContextFactory.CreateMockHttpContext();
			var mrquest = Moq.Mock.Get(mq.Object.Request);
			mrquest.Setup(r => r.Url).Returns(new Uri(page));
			mrquest.Setup(r => r.Path).Returns(new Uri(page).LocalPath); 
			var ctx = mq.Object;
			GlobalConfiguration.Configuration.HttpClientWrapper = new MockHttpClientWrapper((url, httpContent) =>
			{
				var content = httpContent.ReadAsStringAsync().Result;
				var kvList = content.Split('&').ToDictionary(k => k.Split('=')[0], v => v.Split('=')[1]);

				Check.That(kvList).ContainsKey("t");
				Check.That(kvList["t"]).IsEqualTo("pageview");
				Check.That(kvList).ContainsKey("dl");
				var unescapePage = System.Uri.UnescapeDataString(kvList["dl"]);
				Check.That(unescapePage).IsEqualTo(page);
			});

			var track = new Aquila.PageTrack(ctx);
			await track.SendAsync();
		}

		[TestMethod]
		public async Task Send_PageView_With_Referer()
		{
			var page = "http://www.test.com/mypage/?param=abcd&param2=5.8";
			var referer = "http://www.google.com/q=keytest";
			var mq = MockHttpContextFactory.CreateMockHttpContext();
			var mrquest = Moq.Mock.Get(mq.Object.Request);
			mrquest.Setup(r => r.Url).Returns(new Uri(page));
			mrquest.Setup(r => r.Path).Returns(new Uri(page).LocalPath);
			mrquest.Setup(r => r.UrlReferrer).Returns(new Uri(referer));
			var ctx = mq.Object;
			GlobalConfiguration.Configuration.HttpClientWrapper = new MockHttpClientWrapper((url, httpContent) =>
			{
				var content = httpContent.ReadAsStringAsync().Result;
				var kvList = content.Split('&').ToDictionary(k => k.Split('=')[0], v => v.Split('=')[1]);

				var unescapeReferer = System.Uri.UnescapeDataString(kvList["dr"]);
				Check.That(unescapeReferer).IsEqualTo(referer);
			});

			var track = new Aquila.PageTrack(ctx);
			await track.SendAsync();
		}

		[TestMethod]
		public async Task Send_Fake_PageView()
		{
			var page = "http://www.test.com/mypage/?param=abcd&param2=5.8";
			var uri = new Uri(page);

			GlobalConfiguration.Configuration.HttpClientWrapper = new MockHttpClientWrapper((url, httpContent) =>
			{
				var content = httpContent.ReadAsStringAsync().Result;
				var kvList = content.Split('&').ToDictionary(k => k.Split('=')[0], v => v.Split('=')[1]);

				Check.That(kvList["t"]).IsEqualTo("pageview");
				var encodedPage = System.Web.HttpUtility.UrlEncode(page);
				Check.That(kvList["dl"]).IsEqualIgnoringCase(encodedPage);
				Check.That(Convert.ToBoolean(kvList["ni"])).IsTrue();
				Check.That(kvList["dh"]).IsEqualTo(uri.Host);
				var encodedPath = System.Web.HttpUtility.UrlEncode(uri.PathAndQuery);
				Check.That(kvList["dp"]).IsEqualIgnoringCase(encodedPath);
				var encodedTitle = System.Web.HttpUtility.UrlPathEncode("page title");
				Check.That(kvList["dt"]).IsEqualIgnoringCase(encodedTitle);
			});

			var track = new Aquila.PageTrack();
			track.NonInteraction = true;
			track.Url = page;
			track.HostName = uri.Host;
			track.PathAndQuery = uri.PathAndQuery;
			track.Title = "page title";
			await track.SendAsync();
		}


		[TestMethod]
		public void Send_Synchronized_Simple_PageView()
		{
			var page = "http://www.test.com/mypage/?param=abcd&param2=5.8";
			var mq = MockHttpContextFactory.CreateMockHttpContext();
			var mrquest = Moq.Mock.Get(mq.Object.Request);
			mrquest.Setup(r => r.Url).Returns(new Uri(page));
			mrquest.Setup(r => r.Path).Returns(new Uri(page).LocalPath);
			var ctx = mq.Object;
			GlobalConfiguration.Configuration.HttpClientWrapper = new MockHttpClientWrapper((url, httpContent) =>
			{
				var content = httpContent.ReadAsStringAsync().Result;
				var kvList = content.Split('&').ToDictionary(k => k.Split('=')[0], v => v.Split('=')[1]);

				Check.That(kvList).ContainsKey("t");
				Check.That(kvList["t"]).IsEqualTo("pageview");
				Check.That(kvList).ContainsKey("dl");
				var unescapePage = System.Uri.UnescapeDataString(kvList["dl"]);
				Check.That(unescapePage).IsEqualTo(page);
			});

			var track = new Aquila.PageTrack(ctx);
			track.Send();
		}

	}
}
