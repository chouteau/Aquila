namespace Aquila
{
    internal class PromotionTrack
	{
		/// <summary>
		/// The promotion ID. Promotion index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: SHIP
		/// Example usage: promo<promoIndex>id=SHIP
		/// </example>
		[Parameter(@"promo<index>id")]
		public string PromotionId { get; set; }

		/// <summary>
		/// The name of the promotion. Promotion index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Free Shipping
		/// Example usage: promo<promoIndex>nm=Free%20Shipping
		/// </example>
		[Parameter(@"promo<index>nm")]
		public string PromotionName { get; set; }

		/// <summary>
		/// The creative associated with the promotion. Promotion index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: Shipping Banner
		/// Example usage: promo<promoIndex>cr=Shipping%20Banner
		/// </example>
		[Parameter(@"promo<index>cr")]
		public string PromotionCreative { get; set; }

		/// <summary>
		/// The position of the creative. Promotion index must be a positive integer between 1 and 200, inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using this field.
		/// </summary>
		/// <example>
		/// Example value: banner_slot_1
		/// Example usage: promo<promoIndex>ps=banner_slot_1
		/// </example>
		[Parameter(@"promo<index>ps")]
		public int PromotionPosition { get; set; }

	}
}
