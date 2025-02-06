using Microsoft.EntityFrameworkCore;
using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(u => u.Tenant)
                .WithMany(t => t.Users)
                .HasForeignKey(u => u.TenantID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Product>()
                .HasOne(p => p.Tenant)
                .WithMany(t => t.Products)
                .HasForeignKey(p => p.TenantID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Category>()
        .HasOne(c => c.ParentCategory)
        .WithMany(c => c.SubCategories)
        .HasForeignKey(c => c.ParentCategoryID)
        .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Order>()
                .HasOne(o => o.Tenant)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TenantID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductID, pc.CategoryID });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ProductImage>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Translation>()
      .HasOne(t => t.Tenant)
      .WithMany()
      .HasForeignKey(t => t.TenantID)
      .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Setting>()
                .HasOne(s => s.Tenant)
                .WithMany()
                .HasForeignKey(s => s.TenantID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
