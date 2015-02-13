using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NFluent;

namespace Aquila.Tests
{
	[TestClass]
	public class EventTrackerTests
	{
		[TestInitialize]
		public void Initialize()
		{
			MockHttpContextFactory = new MockHttpContextFactory();
		}

		protected MockHttpContextFactory MockHttpContextFactory { get; private set; }

		[TestMethod]
		public async Task Send_Event()
		{
			GlobalConfiguration.Configuration.HttpClientWrapper = new MockHttpClientWrapper((url, httpContent) =>
			{
				var content = httpContent.ReadAsStringAsync().Result;
				var kvList = content.Split('&').ToDictionary(k => k.Split('=')[0], v => v.Split('=')[1]);

				Check.That(kvList).ContainsKey("t");
				Check.That(kvList["t"]).IsEqualTo("event");
				Check.That(kvList["ec"]).IsEqualTo("category");
				Check.That(kvList["ea"]).IsEqualTo("action");
				Check.That(kvList["el"]).IsEqualTo("label");
				Check.That(kvList["ev"]).IsEqualTo("10");
			});

			var evt = new Aquila.EventTrack();
			evt.Action = "action";
			evt.Category = "category";
			evt.Label = "label";
			evt.Value = 10;
			await evt.SendAsync();
		}
	}
}
