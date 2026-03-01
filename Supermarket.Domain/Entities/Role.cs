using Supermarket.Domain.Common;

namespace Supermarket.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; private set; }

        private Role() { } // for EF Core

        public Role(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required");

            CreatedAt = DateTime.UtcNow;
            Name = name;
        }
    }
}
