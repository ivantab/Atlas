using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Services.Querys
{
    public class MovementDto
    {
        public MovementDto()
        {
            Exercises = new HashSet<ExerciseDto>();
            TrsSecondaryMusclesInMovements = new HashSet<TrsSecondaryMusclesInMovementDto>();
        }

        public int IdMovement { get; set; }
        public string Name { get; set; }
        public int IdDiscipline { get; set; }
        public int MainMuscle { get; set; }
        public int IdDifficulty { get; set; }
        public string Description { get; set; }

        public virtual DisciplineDto IdDisciplineNavigation { get; set; }
        public virtual MuscleDto MainMuscleNavigation { get; set; }
        public virtual ICollection<ExerciseDto> Exercises { get; set; }
        public virtual ICollection<TrsSecondaryMusclesInMovementDto> TrsSecondaryMusclesInMovements { get; set; }
    }
}
