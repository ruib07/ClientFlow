using ClientFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientFlow.Infrastructure.Configurations;

public class ProjectsConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.StartDate).IsRequired();
        builder.Property(p => p.EndDate);
        builder.Property(p => p.Status).IsRequired();
        builder.Property(p => p.Budget).HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.Client)
               .WithMany(c => c.Projects)
               .HasForeignKey(p => p.ClientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(e => e.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(e => e.UpdatedAt)
               .IsRequired(false);
    }
}
