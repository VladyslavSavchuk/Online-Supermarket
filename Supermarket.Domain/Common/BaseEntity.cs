namespace Supermarket.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; protected private set; }

        public DateTime CreatedAt { get; protected private set; }

        public DateTime? UpdatedAt { get; protected private set; }

        public bool IsDeleted { get; protected private set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
