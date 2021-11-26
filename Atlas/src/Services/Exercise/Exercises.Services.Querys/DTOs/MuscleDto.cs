using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Services.Querys
{
    public class MuscleDto
    {
        public MuscleDto()
        {
            Movements = new HashSet<MovementDto>();
            TrsSecondaryMusclesInMovements = new HashSet<TrsSecondaryMusclesInMovementDto>();
        }

        public int IdMuscle { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }

        public virtual LocationDto Location { get; set; }
        public virtual ICollection<MovementDto> Movements { get; set; }
        public virtual ICollection<TrsSecondaryMusclesInMovementDto> TrsSecondaryMusclesInMovements { get; set; }
    }
}
