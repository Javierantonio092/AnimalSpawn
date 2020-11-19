using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSpawn.Domain.DTOs
{
    public class CountryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Isocode { get; set; }
        public int? Region { get; set; }   
    }
}
