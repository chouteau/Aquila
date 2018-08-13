namespace Aquila
{
    internal class ProductCustomDimension
    {
        /// <summary> A product-level custom dimension where dimension index is a positive integer
        /// between 1 and 200, inclusive. Product index must be a positive integer between 1 and 200,
        /// inclusive. For analytics.js the Enhanced Ecommerce plugin must be installed before using
        /// this field. </summary> <example> Example value: Member Example usage:
        /// pr<productIndex>cd<dimensionIndex>=Member </example>
        [Parameter(@"pr<index>cd<dindex>")]
        public string Dimension { get; set; }
    }
}