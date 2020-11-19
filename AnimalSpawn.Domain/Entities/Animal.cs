using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalSpawn.Domain.Entities
{
    public partial class Animal : BaseEntity
    {
        public Animal()
        {
            Photos = new HashSet<Photo>();
            Sightings = new HashSet<Sighting>();
        }
    
        public int SpeciesId { get; set; }
        public int FamilyId { get; set; }
        public int GenusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Gender { get; set; }
        public DateTime? CaptureDate { get; set; }
        public string CaptureCondition { get; set; }
        public float? Weight { get; set; }
        public float? Height { get; set; }
        public int? EstimatedAge { get; set; }

        public virtual Family Family { get; set; }
        public virtual Genu Genus { get; set; }
        public virtual Species Species { get; set; }
        public virtual RfidTag RfidTag { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Sighting> Sightings { get; set; }
    }
}
