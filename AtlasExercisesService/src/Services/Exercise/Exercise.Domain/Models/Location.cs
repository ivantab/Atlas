using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Domain.Models
{
    public partial class Location
    {
        public Location()
        {
            Muscles = new HashSet<Muscle>();
        }

        public int LocationId { get; set; }
        public string Ubication { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Muscle> Muscles { get; set; }
    }
}
