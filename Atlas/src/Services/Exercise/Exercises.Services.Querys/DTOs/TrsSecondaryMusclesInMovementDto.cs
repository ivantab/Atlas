using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Services.Querys
{
    public class TrsSecondaryMusclesInMovementDto
    {
        public int IdMuscleMovement { get; set; }
        public int IdMovement { get; set; }
        public int IdMuscle { get; set; }

        public virtual MovementDto IdMovementNavigation { get; set; }
        public virtual MuscleDto IdMuscleNavigation { get; set; }
    }
}
