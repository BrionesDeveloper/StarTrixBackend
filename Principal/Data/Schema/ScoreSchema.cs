using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewSystem.Domain.Score;

namespace NewSystem.Data.Schema
{
    public class ScoreSchema : IEntityTypeConfiguration<Score>
    {
        public void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.ToTable("Scores");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedNever();

            builder.Property(s => s.Value).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();

            builder.HasOne(s => s.Player)
                .WithMany(p => p.Scores)
                .HasForeignKey(s => s.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(s => new { s.Value, s.CreatedAt });
        }
    }
}
