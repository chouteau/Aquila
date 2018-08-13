using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aquila.Tests
{
    [TestClass]
    public class TransactionTrackerTests
    {
        [TestInitialize]
        public void Initialize()
        {
            MockHttpContextFactory = new MockHttpContextFactory();
        }

        protected MockHttpContextFactory MockHttpContextFactory { get; private set; }

        [TestMethod]
        public async Task Send_Online_Transaction()
        {
            var page = "http://www.test.com/checkout";
            var mq = MockHttpContextFactory.CreateMockHttpContext();
            var mrquest = Moq.Mock.Get(mq.Object.Request);
            mrquest.Setup(r => r.Url).Returns(new Uri(page));
            mrquest.Setup(r => r.Path).Returns(new Uri(page).LocalPath);
            var ctx = mq.Object;
            GlobalConfiguration.Configuration.HttpClientWrapper = new MockHttpClientWrapper((url, httpContent) =>
            {
                var content = httpContent.ReadAsStringAsync().Result;
                var kvList = content.Split('&').ToDictionary(k => k.Split('=')[0], v => v.Split('=')[1]);

                var hitType = kvList["t"];
                if (hitType == "transaction")
                {
                    Check.That(kvList["ti"]).IsEqualTo("Tran01");
                    Check.That(kvList["tr"]).IsEqualTo("100.0");
                    Check.That(kvList["ts"]).IsEqualTo("10.0");
                    Check.That(kvList["tt"]).IsEqualTo("20.0");
                }
                else if (hitType == "item")
                {
                    Check.That(kvList["ti"]).IsEqualTo("Tran01");
                    Check.That(kvList["in"]).IsEqualTo("item1Name");
                    Check.That(kvList["ip"]).IsEqualTo("10.0");
                    Check.That(kvList["iq"]).IsEqualTo("9");
                    Check.That(kvList["ic"]).IsEqualTo("item1");
                    Check.That(kvList["iv"]).IsEqualTo("cat1");
                }
                Check.That(kvList["cu"]).IsEqualTo(GlobalConfiguration.Configuration.Settings.CurrencyCode);
            });

            var transaction = new TransactionTrack();
            transaction.TransactionId = "Tran01";
            transaction.RevenueWithTax = 100.0m;
            transaction.ShippingWithTax = 10.0m;
            transaction.Tax = 20.0m;
            transaction.ItemList.Add(new TransactionItem()
            {
                Code = "item1",
                Category = "cat1",
                Name = "item1Name",
                PriceWithTax = 10.0m,
                Quantity = 9
            });

            await transaction.SendAsync();
        }

        [TestMethod]
        public async Task Send_Offline_Transaction()
        {
            GlobalConfiguration.Configuration.HttpClientWrapper = new MockHttpClientWrapper((url, httpContent) =>
            {
                var content = httpContent.ReadAsStringAsync().Result;
                var kvList = content.Split('&').ToDictionary(k => k.Split('=')[0], v => v.Split('=')[1]);

                var hitType = kvList["t"];
                Check.That(hitType).IsNotNull();
                if (hitType == "transaction")
                {
                    Check.That(kvList["ti"]).IsEqualTo("Tran01");
                    Check.That(kvList["tr"]).IsEqualTo("100.0");
                    Check.That(kvList["ts"]).IsEqualTo("10.0");
                    Check.That(kvList["tt"]).IsEqualTo("20.0");
                }
                else if (hitType == "item")
                {
                    Check.That(kvList["in"]).IsEqualTo("item1Name");
                    Check.That(kvList["ip"]).IsEqualTo("10.0");
                    Check.That(kvList["iq"]).IsEqualTo("9");
                    Check.That(kvList["ic"]).IsEqualTo("item1");
                    Check.That(kvList["iv"]).IsEqualTo("cat1");
                }
                Check.That(kvList["cu"]).IsEqualTo(GlobalConfiguration.Configuration.Settings.CurrencyCode);
                Check.That(kvList["cid"]).IsEqualTo("cdef");
            });

            var transaction = new TransactionTrack();
            transaction.ClientId = "cdef";
            transaction.TransactionId = "Tran01";
            transaction.RevenueWithTax = 100.0m;
            transaction.ShippingWithTax = 10.0m;
            transaction.Tax = 20.0m;
            transaction.ItemList.Add(new TransactionItem()
            {
                Code = "item1",
                Category = "cat1",
                Name = "item1Name",
                PriceWithTax = 10.0m,
                Quantity = 9
            });

            await transaction.SendAsync();
        }
    }
}