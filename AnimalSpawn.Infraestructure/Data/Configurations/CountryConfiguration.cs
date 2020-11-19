using AnimalSpawn.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalSpawn.Infrastructure.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");

            builder.Property(e => e.Code)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.CreateAt).HasColumnType("datetime");

            builder.Property(e => e.Isocode)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ISOCode");

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Status).HasDefaultValueSql("((1))");

            builder.Property(e => e.UpdateAt).HasColumnType("datetime");
        }
    }
}
