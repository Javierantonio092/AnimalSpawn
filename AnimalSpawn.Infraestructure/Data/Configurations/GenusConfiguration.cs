using AnimalSpawn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalSpawn.Infrastructure.Data.Configurations
{
    public class GenusConfiguration : IEntityTypeConfiguration<Genu>
    {
        public void Configure(EntityTypeBuilder<Genu> builder)
        {
           builder.Property(e => e.Code)
                  .HasMaxLength(15)
                  .IsUnicode(false);

           builder.Property(e => e.CreateAt).HasColumnType("datetime");

           builder.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);

           builder.Property(e => e.Status).HasDefaultValueSql("((1))");

           builder.Property(e => e.UpdateAt).HasColumnType("datetime");
        }
    }
}
