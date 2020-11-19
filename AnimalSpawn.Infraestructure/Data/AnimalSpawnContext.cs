using System;
using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AnimalSpawn.Infrastructure.Data
{
    public partial class AnimalSpawnContext : DbContext
    {
        public AnimalSpawnContext()
        {
        }

        public AnimalSpawnContext(DbContextOptions<AnimalSpawnContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Genu> Genus { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<ProtectedArea> ProtectedAreas { get; set; }
        public virtual DbSet<Researcher> Researchers { get; set; }
        public virtual DbSet<RfidTag> RfidTags { get; set; }
        public virtual DbSet<Sighting> Sightings { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration<Animal>(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration<Country>(new CountryConfiguration());
            modelBuilder.ApplyConfiguration<Family>(new FamilyConfiguration());
            modelBuilder.ApplyConfiguration<Genu>(new GenusConfiguration());
            modelBuilder.ApplyConfiguration<Photo>(new PhotoConfiguration());
            modelBuilder.ApplyConfiguration<ProtectedArea>(new ProtectedAreaConfiguration());
            modelBuilder.ApplyConfiguration<Researcher>(new ResearcherConfiguration());
            modelBuilder.ApplyConfiguration<RfidTag>(new RFidTagConfiguration());
            modelBuilder.ApplyConfiguration<Sighting>(new SightingConfiguration());
            modelBuilder.ApplyConfiguration<Species>(new SpeciesConfiguration());
            modelBuilder.ApplyConfiguration<UserAccount>(new UserAccountConfiguration());

        }

 
    }
}
