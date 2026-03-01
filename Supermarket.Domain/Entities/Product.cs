using Supermarket.Domain.Common;

namespace Supermarket.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int StockQuantity { get; private set; }

        public int CategoryId { get; private set; }

        private Product() { } // for EF Core

        public Product(string name, decimal price, int stockQuantity, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required");

            if (price <= 0)
                throw new ArgumentException("Price must be positive");

            if (stockQuantity < 0)
                throw new ArgumentException("Stock must be positive");

            CreatedAt = DateTime.UtcNow;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Price must be positive");

            Price = newPrice;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive");

            if (StockQuantity < quantity)
                throw new InvalidOperationException("Not enough stock");

            StockQuantity -= quantity;
        }
    }
}
