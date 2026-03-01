using Supermarket.Domain.Common;

namespace Supermarket.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }

        private Category() { } // for EF Core

        public Category(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required");

            CreatedAt = DateTime.UtcNow;
            Name = name;
        }
    }
}
