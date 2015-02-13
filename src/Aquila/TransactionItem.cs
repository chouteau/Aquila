using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class TransactionItem
	{
		public string Name { get; set; }
		public decimal PriceWithTax { get; set; }
		public int Quantity { get; set; }
		public string Code { get; set; }
		public string Category { get; set; }
		public string CurrencyCode { get; set; }
	}
}
