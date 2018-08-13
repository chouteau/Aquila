using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aquila
{
    public class TransactionTrack : TrackBuilder
    {
        public TransactionTrack()
        {
            ItemList = new List<TransactionItem>();
        }

        public TransactionTrack(System.Web.HttpContextBase ctx)
            : base(ctx)
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
            await base.SendAsync();
            foreach (var item in ItemList)
            {
                var trackItem = m_Track.Clone() as Track;
                trackItem.HitType = "item";
                trackItem.ItemName = item.Name;
                trackItem.ItemPrice = item.PriceWithTax;
                trackItem.ItemQuantity = item.Quantity;
                trackItem.ItemCode = item.Code;
                trackItem.ItemCategory = item.Category;
                await base.SendAsync(trackItem);
            }
        }

        public override void Send()
        {
            base.Send();
            foreach (var item in ItemList)
            {
                var trackItem = m_Track.Clone() as Track;
                trackItem.HitType = "item";
                trackItem.ItemName = item.Name;
                trackItem.ItemPrice = item.PriceWithTax;
                trackItem.ItemQuantity = item.Quantity;
                trackItem.ItemCode = item.Code;
                trackItem.ItemCategory = item.Category;
                base.Send(trackItem);
            }
        }
    }
}