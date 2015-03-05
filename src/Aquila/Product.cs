using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila
{
	public class Product
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public string Code { get; set; }
		public string Category { get; set; }
		public string Brand { get; set; }
		public string CurrencyCode { get; set; }
		public int? Position { get; set; }
	}
}
