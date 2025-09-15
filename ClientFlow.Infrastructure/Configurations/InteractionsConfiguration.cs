using ClientFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientFlow.Infrastructure.Configurations;

public class InteractionsConfiguration : IEntityTypeConfiguration<Interaction>
{
    public void Configure(EntityTypeBuilder<Interaction> builder)
    {
        builder.ToTable("Interactions");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Type).IsRequired();
        builder.Property(i => i.Date).IsRequired();
        builder.Property(i => i.Notes).HasMaxLength(1000);

        builder.HasOne(i => i.Client)
               .WithMany(c => c.Interactions)
               .HasForeignKey(i => i.ClientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(e => e.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(e => e.UpdatedAt)
               .IsRequired(false);
    }
}
