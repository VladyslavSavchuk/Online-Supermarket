using Supermarket.Domain.Common;

namespace Supermarket.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; private set; }
        public decimal TotalAmount { get; private set; }

        private readonly List<OrderItem> _items = new();

        public IReadOnlyCollection<OrderItem> Items => _items;

        private Order() { } // for EF Core

        public Order(int userId, List<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentException("Order items can't be empty");

            CreatedAt = DateTime.UtcNow;
            UserId = userId;
            TotalAmount = items.Sum( it => it.UnitPrice * it.Quantity);
            _items = new List<OrderItem>(items);
        }
    }
}
