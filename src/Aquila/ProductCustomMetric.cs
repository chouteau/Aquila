namespace Aquila
{
    public class ProductCustomMetric
	{
		/// <summary>
		/// A product-level custom metric where metric index is a positive integer between 1 and 200, inclusive. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: 28
		/// Example usage: pr<productIndex>cm<metricIndex>=28
		/// </example>
		[Parameter(@"pr<index>cm<dindex>")]
		public int Metric { get; set; }

	}
}
