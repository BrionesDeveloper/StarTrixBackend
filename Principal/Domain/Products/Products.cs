using NewSystem.Domain.Players;

namespace NewSystem.Domain.Products
{
    /// <summary>
    /// Entity for products used in the game.
    /// </summary>
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();  // PK

        public string Name { get; set; } = string.Empty;  // Display name
        public string Sku { get; set; } = string.Empty;   // Unique SKU

        public string ImageUrl { get; set; } = string.Empty;

        public int FootprintW { get; set; } = 2;
        public int FootprintH { get; set; } = 2;

        // Legacy system mappings
        public string Code { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public bool IsComposed { get; set; }

        public static Product Create(string code, int categoryId, bool isComposed, string imageUrl, string name, string sku, int fw, int fh)
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Code = code,
                CategoryId = categoryId,
                IsComposed = isComposed,
                ImageUrl = imageUrl,
                Name = name,
                Sku = sku,
                FootprintW = fw,
                FootprintH = fh
            };
        }

        public void UpdateFootprint(int fw, int fh) => (FootprintW, FootprintH) = (fw, fh);
    }
}
