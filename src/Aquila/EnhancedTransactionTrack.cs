using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class EnhancedTransactionTrack : TrackBuilder
	{
		public EnhancedTransactionTrack()
		{
			ProductList = new List<Product>();
		}

		public EnhancedTransactionTrack(System.Web.HttpContextBase ctx)
			: base(ctx)
		{
			ProductList = new List<Product>();
			DocumentHostName = ctx.Request.Url.Host;
			DocumentPath = ctx.Request.Url.PathAndQuery;
		}

		protected override string HitType
		{
			get { return "pageview"; }
		}

		public IList<Product> ProductList { get; private set; }

		public decimal? Tax
		{
			get
			{
				return m_Track.TransactionTax;
			}
			set
			{
				m_Track.TransactionTax = value;
			}
		}

		public decimal? Shipping
		{
			get
			{
				return m_Track.TransactionShipping;
			}
			set
			{
				m_Track.TransactionShipping = value;
			}
		}

		public decimal? Revenue
		{
			get
			{
				return m_Track.TransactionRevenue;
			}
			set
			{
				m_Track.TransactionRevenue = value;
			}
		}

		public string TransactionAffiliation
		{
			get
			{
				return m_Track.TransactionAffiliation;
			}
			set
			{
				m_Track.TransactionAffiliation = value;
			}
		}

		public string TransactionId
		{
			get
			{
				return m_Track.TransactionId;
			}
			set
			{
				m_Track.TransactionId = value;
			}
		}

		public string DocumentHostName
		{
			get
			{
				return m_Track.DocumentHostName;
			}
			set
			{
				m_Track.DocumentHostName = value;
			}
		}

		public string DocumentPath
		{
			get
			{
				return m_Track.DocumentPath;
			}
			set
			{
				m_Track.DocumentPath = value;
			}
		}

		public string DocumentTitle
		{
			get
			{
				return m_Track.DocumentTitle ;
			}
			set
			{
				m_Track.DocumentTitle = value;
			}
		}

		private void PrepareToSend()
		{
			m_Track.ProductAction = "purchase";
			foreach (var item in ProductList)
			{
				m_Track.ProductList.Add(new ProductTrack()
				{
					ProductSKU = item.Code,
					ProductPrice = item.Price,
					ProductQuantity = item.Quantity,
					ProductName = item.Name,
					ProductCategory = item.Category,
					ProductBrand = item.Brand,
					ProductPosition = item.Position.GetValueOrDefault(1)
				});
			}
		}

		public override async Task SendAsync()
		{
			PrepareToSend();
			await base.SendAsync();
		}

		public override void Send()
		{
			PrepareToSend();
			base.Send();
		}
	}
}
