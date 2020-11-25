using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class TransactionTrack : TrackBuilder
	{
		public TransactionTrack(
			Settings settings,
			ILogger<TrackBuilder> logger,
			TrackSender trackSender)
			: base(settings, logger, trackSender)
		{
			ItemList = new List<TransactionItem>();
		}

		protected override string HitType
		{
			get { return "transaction"; }
		}

		public IList<TransactionItem> ItemList { get; private set; }

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

		public decimal? ShippingWithTax
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

		public decimal? RevenueWithTax
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

		public override async Task SendAsync()
		{
			foreach (var item in ItemList)
			{
				var trackItem = m_Track.Clone() as Track;
				trackItem.HitType = "item";
				trackItem.ItemName = item.Name;
				trackItem.ItemPrice = item.PriceWithTax;
				trackItem.ItemQuantity = item.Quantity;
				trackItem.ItemCode = item.Code;
				trackItem.ItemCategory = item.Category;
				await TrackSender.SendAsync(trackItem);
			}
		}
	}
}
