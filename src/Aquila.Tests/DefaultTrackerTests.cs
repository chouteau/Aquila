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
	public class DefaultTrackerTests
	{
		[TestInitialize]
		public void Initialize()
		{
			MockHttpContextFactory = new MockHttpContextFactory();
		}

		protected MockHttpContextFactory MockHttpContextFactory { get; private set; }

		[TestMethod]
		public async Task Send_Default()
		{
			GlobalConfiguration.Configuration.HttpClientWrapper = new MockHttpClientWrapper((url, httpContent) =>
			{
				var content = httpContent.ReadAsStringAsync().Result;
				var kvList = content.Split('&').ToDictionary(k => k.Split('=')[0], v => v.Split('=')[1]);

				Check.That(kvList).ContainsKey("t");
			});

			var track = new Aquila.DefaultTrack();
			await track.SendAsync();
		}

		[TestMethod]
		public async Task Send_Default_With_Campaign()
		{
			GlobalConfiguration.Configuration.HttpClientWrapper = new MockHttpClientWrapper((url, httpContent) =>
			{
				var content = httpContent.ReadAsStringAsync().Result;
				var kvList = content.Split('&').ToDictionary(k => k.Split('=')[0], v => v.Split('=')[1]);

				Check.That(kvList).ContainsKey("t");
				Check.That(kvList["cc"]).IsEqualTo("campaignContent");
				Check.That(kvList["ci"]).IsEqualTo("campaignId");
				Check.That(kvList["ck"]).IsEqualTo("campaignKeyword");
				Check.That(kvList["cm"]).IsEqualTo("campaignMedium");
				Check.That(kvList["cn"]).IsEqualTo("campaignName");
				Check.That(kvList["cs"]).IsEqualTo("campaignSource");
			});

			var track = new Aquila.DefaultTrack();
			track.Campaign.CampaignContent = "campaignContent";
			track.Campaign.CampaignId = "campaignId";
			track.Campaign.CampaignKeyword = "campaignKeyword";
			track.Campaign.CampaignMedium = "campaignMedium";
			track.Campaign.CampaignName = "campaignName";
			track.Campaign.CampaignSource = "campaignSource";
			await track.SendAsync();
		}


	}
}
