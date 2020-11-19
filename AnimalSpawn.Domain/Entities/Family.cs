using System;
using System.Collections.Generic;

#nullable disable

namespace AnimalSpawn.Domain.Entities
{
    public partial class Family : BaseEntity
    {
        public Family()
        {
            Animals = new HashSet<Animal>();
        }

        public string CommonName { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
