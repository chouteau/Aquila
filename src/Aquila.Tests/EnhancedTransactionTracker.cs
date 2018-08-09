using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NFluent;

namespace Aquila.Tests
{
    [TestClass]
    public class EnhancedTransactionTracker
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
            var page = "http://www.test.com/conversion";
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
                Check.That(kvList["v"]).IsEqualTo("1");
                Check.That(kvList["tid"]).IsEqualTo("ABCD");
                Check.That(kvList["cid"]).IsEqualTo("cdef");
                Check.That(kvList["t"]).IsEqualTo("pageview");
                Check.That(Uri.UnescapeDataString(kvList["dp"])).IsEqualTo("/conversion");
                Check.That(kvList["ti"]).IsEqualTo("Tran01");
                Check.That(kvList["tr"]).IsEqualTo("100.0");
                Check.That(kvList["ts"]).IsEqualTo("10.0");
                Check.That(kvList["tt"]).IsEqualTo("20.0");
                Check.That(kvList["pa"]).IsEqualTo("purchase");
                Check.That(kvList["pr1id"]).IsEqualTo("item1");
                Check.That(kvList["pr1nm"]).IsEqualTo("item1Name");
                Check.That(kvList["pr1ca"]).IsEqualTo("cat1");
                Check.That(kvList["pr1br"]).IsEqualTo("brand1");
                Check.That(kvList["pr1ps"]).IsEqualTo("1");
                Check.That(kvList["pr2id"]).IsEqualTo("item2");
                Check.That(kvList["pr2nm"]).IsEqualTo("item2Name");
                Check.That(kvList["pr2ca"]).IsEqualTo("cat2");
                Check.That(kvList["pr2br"]).IsEqualTo("brand2");
                Check.That(kvList["pr2ps"]).IsEqualTo("1");
            });

            var transaction = new EnhancedTransactionTrack(ctx);
            transaction.ClientId = "cdef";
            transaction.TransactionId = "Tran01";
            transaction.Revenue = 100.0m;
            transaction.Shipping = 10.0m;
            transaction.Tax = 20.0m;
            transaction.ProductList.Add(new Product()
            {
                Code = "item1",
                Category = "cat1",
                Name = "item1Name",
                Brand = "brand1",
                Price = 10.0m,
                Quantity = 9
            });

            transaction.ProductList.Add(new Product()
            {
                Code = "item2",
                Category = "cat2",
                Name = "item2Name",
                Brand = "brand2",
                Price = 5.0m,
                Quantity = 3
            });

            await transaction.SendAsync();
        }
    }
}