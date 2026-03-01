using Supermarket.Domain.Common;

namespace Supermarket.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; private set; }

        public string FullName { get; private set; }

        public decimal Balance { get; private set; }

        public int RoleId { get; private set; }

        private User() { } // for EF Core

        public User(string userName, string fullName, decimal balance, int roleId)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("User name is required");

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name is required");

            if (balance < 0)
                throw new ArgumentException("Balance must be positive");

            CreatedAt = DateTime.UtcNow;
            UserName = userName;
            FullName = fullName;
            Balance = balance;
            RoleId = roleId;
        }

        public void DeductBalance(decimal amount)
        {
            if (Balance < amount)
                throw new InvalidOperationException("Not enough money to purchase");

            Balance -= amount;
        }
    }
}
