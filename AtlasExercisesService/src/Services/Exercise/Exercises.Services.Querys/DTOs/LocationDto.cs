using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Services.Querys
{
    public partial class LocationDto
    {
        public LocationDto()
        {
            Muscles = new HashSet<MuscleDto>();
        }

        public int LocationId { get; set; }
        public string Ubication { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MuscleDto> Muscles { get; set; }
    }
}
