namespace Aquila
{
    public class ProductImpressionTrack
	{
		/// <summary>
		/// The list or collection to which a product belongs. Impression List index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Search Results
		/// Example usage: il<listIndex>nm=Search%20Results
		/// </example>
		[Parameter(@"il<index>nm")]
		public string ProductImpressionListName { get; set; }

		/// <summary>
		/// The product ID or SKU. Impression List index must be a positive integer between 1 and 200, inclusive. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: P67890
		/// Example usage: il<listIndex>pi<productIndex>id=P67890
		/// </example>
		[Parameter(@"il<index>pi<pindex>id")]
		public string ProductImpressionSKU { get; set; }

		/// <summary>
		/// The name of the product. Impression List index must be a positive integer between 1 and 200, inclusive. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Android T-Shirt
		/// Example usage: il<listIndex>pi<productIndex>nm=Android%20T-Shirt
		/// </example>
		[Parameter(@"il<index>pi<pindex>nm")]
		public string ProductImpressionName { get; set; }

		/// <summary>
		/// The brand associated with the product. Impression List index must be a positive integer between 1 and 200, inclusive. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Google
		/// Example usage: il<listIndex>pi<productIndex>br=Google
		/// </example>
		[Parameter(@"il<index>pi<pindex>br")]
		public string ProductImpressionBrand { get; set; }

		/// <summary>
		/// The category to which the product belongs. Impression List index must be a positive integer between 1 and 200, inclusive. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Apparel
		/// Example usage: il<listIndex>pi<productIndex>ca=Apparel
		/// </example>
		[Parameter(@"il<index>pi<pindex>ca")]
		public string ProductImpressionCategory { get; set; }

		/// <summary>
		/// The variant of the product. Impression List index must be a positive integer between 1 and 200, inclusive. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Black
		/// Example usage: il<listIndex>pi<productIndex>va=Black
		/// </example>
		[Parameter(@"il<index>pi<pindex>va")]
		public string ProductImpressionVariant { get; set; }

		/// <summary>
		/// The product's position in a list or collection. Impression List index must be a positive integer between 1 and 200, inclusive. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: 2
		/// Example usage: il<listIndex>pi<productIndex>ps=2
		/// </example>
		[Parameter(@"il<index>pi<pindex>ps")]
		public int ProductImpressionPosition { get; set; }

		/// <summary>
		/// The price of a product. Impression List index must be a positive integer between 1 and 200, inclusive. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: 29.20
		/// Example usage: il<listIndex>pi<productIndex>pr=29.20
		/// </example>
		[Parameter(@"il<index>pi<pindex>pr")]
		public decimal ProductImpressionPrice { get; set; }

		/// <summary>
		/// A product-level custom dimension where dimension index is a positive integer between 1 and 200, inclusive. Impression List index must be a positive integer between 1 and 200, inclusive. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Member
		/// Example usage: il<listIndex>pi<productIndex>cd<dimensionIndex>=Member
		/// </example>
		[Parameter(@"il<index>pi<pindex>cd<dindex>")]
		public string ProductImpressionCustomDimension { get; set; }

		/// <summary>
		/// A product-level custom metric where metric index is a positive integer between 1 and 200, inclusive. Impression List index must be a positive integer between 1 and 200, inclusive. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: 28
		/// Example usage: il<listIndex>pi<productIndex>cm<metricIndex>=28
		/// </example>
		[Parameter(@"il<index>pi<pindex>cm<dindex>")]
		public int ProductImpressionCustomMetric { get; set; }

	}
}
