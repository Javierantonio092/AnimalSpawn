using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSpawn.Domain.DTOs
{
    public class CountryRequestDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Isocode { get; set; }
        public int? Region { get; set; }
        public DateTime? CreateAt { get; set; }
    }
}
