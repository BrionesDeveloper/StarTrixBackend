using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewSystem.Domain.Products;

namespace NewSystem.Data.Schema
{
    public class ProductSchema : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever(); // You are manually assigning Guid

            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Sku).IsRequired().HasMaxLength(100);
            builder.Property(p => p.ImageUrl).HasMaxLength(500);

            builder.Property(p => p.FootprintW).IsRequired();
            builder.Property(p => p.FootprintH).IsRequired();

            builder.Property(p => p.Code).HasMaxLength(100);
            builder.Property(p => p.CategoryId);
            builder.Property(p => p.IsComposed);

            builder.HasIndex(p => p.Sku).IsUnique();
            builder.HasIndex(p => p.Name);
        }
    }
}
