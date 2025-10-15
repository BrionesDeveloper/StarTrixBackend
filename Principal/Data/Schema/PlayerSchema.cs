using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewSystem.Domain.Player;

namespace NewSystem.Data.Schema
{
    public class PlayerSchema : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Players");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.DisplayName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.CreatedAt).IsRequired();

            builder.HasIndex(p => p.DisplayName).IsUnique();
        }
    }
}
