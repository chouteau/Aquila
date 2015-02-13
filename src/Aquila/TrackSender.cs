using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class TrackSender : IDisposable
	{
		private Track m_Track;

		public TrackSender(Track track)
		{
			m_Track = track;
		}


		public async Task SendTransactionAsync(Transaction transaction)
		{
			m_Track.HitType = "transaction";
			m_Track.TransactionId = transaction.TransactionId;
			m_Track.TransactionAffiliation = transaction.Affiliation;
			m_Track.TransactionRevenue = transaction.RevenueWithTax;
			m_Track.TransactionShipping = transaction.ShippingWithTax;
			m_Track.TransactionTax = transaction.Tax;
			await SendTrackAsync();

			foreach (var item in transaction.ItemList)
			{
				var trackItem = m_Track.Clone() as Track;
				trackItem.HitType = "item";
				trackItem.ItemName = item.Name;
				trackItem.ItemPrice = item.PriceWithTax;
				trackItem.ItemQuantity = item.Quantity;
				trackItem.ItemCode = item.Code;
				trackItem.ItemCategory = item.Category;
				await SendItemAsync(trackItem);
			}
		}

		public async Task SendScreenViewAsync()
		{
			m_Track.HitType = "screenview";
			await SendTrackAsync();
		}

		public async Task SendSocialAsync()
		{
			m_Track.HitType = "social";
			await SendTrackAsync();
		}

		public async Task SendExceptionAsync()
		{
			m_Track.HitType = "exception";
			await SendTrackAsync();
		}

		public async Task SendTimingAsync()
		{
			m_Track.HitType = "timing";
			await SendTrackAsync();
		}

		private async Task SendItemAsync(Track track)
		{
			track.HitType = "item";
			await SendTrackAsync(track);
		}

		private async Task SendTrackAsync(Track track = null)
		{
			var t = track ?? m_Track;

			if (t.TrackingId == null
				|| t.TrackingId.Trim() == string.Empty)
			{
				return;
			}
			var httpContent = t.GetBody();
			await GlobalConfiguration.Configuration.HttpClientWrapper.PostAsync(GlobalConfiguration.Configuration.Settings.UrlEndPoint, httpContent).ContinueWith(task =>
			{
				if (task.IsFaulted)
				{
					GlobalConfiguration.Configuration.Logger.Error(task.Exception);
				}
			});
		}

		public void Dispose()
		{
			m_Track = null;
		}
	}
}
