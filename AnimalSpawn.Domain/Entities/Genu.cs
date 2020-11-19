using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalSpawn.Domain.Entities
{
    public partial class Genu : BaseEntity
    {
        public Genu()
        {
            Animals = new HashSet<Animal>();
        }

        public string Name { get; set; }
        public string Code { get; set; }
        public int? UpdateBy { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
