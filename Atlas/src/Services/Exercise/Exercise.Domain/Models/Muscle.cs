using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Domain.Models
{
    public partial class Muscle
    {
        public Muscle()
        {
            Movements = new HashSet<Movement>();
            TrsSecondaryMusclesInMovements = new HashSet<TrsSecondaryMusclesInMovement>();
        }

        public int IdMuscle { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Movement> Movements { get; set; }
        public virtual ICollection<TrsSecondaryMusclesInMovement> TrsSecondaryMusclesInMovements { get; set; }
    }
}
