using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Domain.Models
{
    public partial class TrsSecondaryMusclesInMovement
    {
        public int IdMuscleMovement { get; set; }
        public int IdMovement { get; set; }
        public int IdMuscle { get; set; }

        public virtual Movement IdMovementNavigation { get; set; }
        public virtual Muscle IdMuscleNavigation { get; set; }
    }
}
