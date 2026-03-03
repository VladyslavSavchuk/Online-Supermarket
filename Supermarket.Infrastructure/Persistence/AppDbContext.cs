using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Entities;

namespace Supermarket.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        #region FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
                {
                        entity.HasKey(p => p.Id);
                        entity.Property(p => p.Id)
                            .ValueGeneratedOnAdd();

                        entity.Property(p => p.Name)
                            .IsRequired()
                            .HasMaxLength(255);

                        entity.Property(p => p.Price)
                            .IsRequired()
                            .HasColumnType("decimal(18,2)");

                        entity.Property(p => p.StockQuantity)
                            .IsRequired();

                        entity.HasOne(p => p.Category)
                            .WithMany(c => c.Products)
                            .HasForeignKey(p => p.CategoryId)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity.Property(p => p.CreatedAt)
                            .IsRequired();

                        entity.Property(p => p.UpdatedAt)
                            .IsRequired(false);

                        entity.Property(p => p.IsDeleted)
                            .IsRequired();
                });

            modelBuilder.Entity<Category>(entity =>
                {
                    entity.HasKey(c => c.Id);
                    entity.Property(c => c.Id)
                        .ValueGeneratedOnAdd();

                    entity.Property(c => c.Name)
                        .IsRequired()
                        .HasMaxLength(255);

                    entity.Property(c => c.CreatedAt)
                        .IsRequired();

                    entity.Property(c => c.UpdatedAt)
                        .IsRequired(false);

                    entity.Property(c => c.IsDeleted)
                        .IsRequired();
                });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(r => r.CreatedAt)
                    .IsRequired();

                entity.Property(r => r.UpdatedAt)
                    .IsRequired(false);

                entity.Property(r => r.IsDeleted)
                    .IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(u => u.UserName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(u => u.FullName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(u => u.Balance)
                     .IsRequired()
                     .HasColumnType("decimal(18,2)");

                entity.HasOne(u => u.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(u => u.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(u => u.CreatedAt)
                    .IsRequired();

                entity.Property(u => u.UpdatedAt)
                    .IsRequired(false);

                entity.Property(u => u.IsDeleted)
                    .IsRequired();
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(oi => oi.Id);
                entity.Property(oi => oi.Id)
                    .ValueGeneratedOnAdd();

                entity.HasOne(oi => oi.Order)
                    .WithMany(o => o.Items)
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(oi => oi.Product)
                    .WithMany()
                    .HasForeignKey(oi => oi.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(oi => oi.UnitPrice)
                     .IsRequired()
                     .HasColumnType("decimal(18,2)");

                entity.Property(oi => oi.Quantity)
                    .IsRequired();

                entity.Property(oi => oi.CreatedAt)
                    .IsRequired();

                entity.Property(oi => oi.UpdatedAt)
                    .IsRequired(false);

                entity.Property(oi => oi.IsDeleted)
                    .IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Id)
                    .ValueGeneratedOnAdd();

                entity.HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(o => o.TotalAmount)
                     .IsRequired()
                     .HasColumnType("decimal(18,2)");

                entity.Property(o => o.CreatedAt)
                    .IsRequired();

                entity.Property(o => o.UpdatedAt)
                    .IsRequired(false);

                entity.Property(o => o.IsDeleted)
                    .IsRequired();
            });
        }
        #endregion
    }
}
