using Supermarket.Domain.Common;

namespace Supermarket.Domain.Entities
{
    public  class OrderItem : BaseEntity
    {
        public int OrderId { get; private set; }

        public int ProductId { get; private set; }

        public decimal UnitPrice { get; private set; }

        public int Quantity { get; private set; }

        private OrderItem() { } // for EF Core

        public OrderItem(int productId, decimal unitPrice, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("quantity must be positive");

            if (unitPrice <= 0)
                throw new ArgumentException("Unit price must be positive");
            
            CreatedAt = DateTime.UtcNow;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
