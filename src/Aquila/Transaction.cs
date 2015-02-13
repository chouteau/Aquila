using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class Transaction
	{
		public Transaction()
		{
			ItemList = new List<TransactionItem>();
		}

		public string TransactionId { get; set; }
		public string Affiliation { get; set; }
		public decimal RevenueWithTax { get; set; }
		public decimal ShippingWithTax { get; set; }
		public decimal Tax { get; set; }
		public string CurrencyCode { get; set; }
		public IList<TransactionItem> ItemList { get; private set; }
	}
}
