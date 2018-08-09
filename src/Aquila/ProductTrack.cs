using System.Collections.Generic;

namespace Aquila
{
    internal class ProductTrack
	{
		public ProductTrack()
		{
			CustomerDimensionList = new List<ProductCustomDimension>();
			CustomMetricList = new List<ProductCustomMetric>();
		}

		/// <summary>
		/// The SKU of the product. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: P12345
		/// Example usage: pr[\d+]id=P12345
		/// </example>
		[Parameter(@"pr<index>id", 500)]
		public string ProductSKU { get; set; }

		/// <summary>
		/// The name of the product. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Android T-Shirt
		/// Example usage: pr<productIndex>nm=Android%20T-Shirt
		/// </example>
		[Parameter(@"pr<index>nm", 500)]
		public string ProductName { get; set; }

		/// <summary>
		/// The brand associated with the product. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Google
		/// Example usage: pr<productIndex>br=Google
		/// </example>
		[Parameter(@"pr<index>br", 500)]
		public string ProductBrand { get; set; }

		/// <summary>
		/// The category to which the product belongs. Product index must be a positive integer between 1 and 200, inclusive. The product category parameter can be hierarchical. Use / as a delimiter to specify up to 5-levels of hierarchy. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Apparel
		/// Example usage: pr<productIndex>ca=Apparel
		///
		/// Example value: Apparel/Mens/T-Shirts
		/// Example usage: pr<productIndex>ca=Apparel%2FMens%2FT-Shirts		
		/// </example>
		[Parameter(@"pr<index>ca", 500)]
		public string ProductCategory { get; set; }

		/// <summary>
		/// The variant of the product. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Black
		/// Example usage: pr<productIndex>va=Black
		/// </example>
		[Parameter(@"pr<index>va", 500)]
		public string ProductVariant { get; set; }

		/// <summary>
		/// The price of a product. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: 29.20
		/// Example usage: pr<productIndex>pr=29.20
		/// </example>
		[Parameter(@"pr<index>pr")]
		public decimal ProductPrice { get; set; }

		/// <summary>
		/// The quantity of a product. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: 2
		/// Example usage: pr<productIndex>qt=2
		/// </example>
		[Parameter(@"pr<index>qt")]
		public int ProductQuantity { get; set; }

		/// <summary>
		/// The coupon code associated with a product. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: SUMMER_SALE13
		/// Example usage: pr<productIndex>cc=SUMMER_SALE13
		/// </example>
		[Parameter(@"pr<index>cc", 500)]
		public string ProductCouponCode { get; set; }

		/// <summary>
		/// The product's position in a list or collection. Product index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: 2
		/// Example usage: pr<productIndex>ps=2
		/// </example>
		[Parameter(@"pr<index>ps")]
		public int ProductPosition { get; set; }


		/// <summary>
		/// List of custom dimensions
		/// </summary>
		public IList<ProductCustomDimension> CustomerDimensionList { get; private set; }

		/// <summary>
		/// List of custom metrics
		/// </summary>
		public IList<ProductCustomMetric> CustomMetricList { get; private set; }
	}
}
