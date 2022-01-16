using System;
using System.Collections.Generic;

namespace Users.services.Proxies.Exercises.Dtos
{
    public class ExerciseDto
    {
        public ExerciseDto()
        {
            TrsExercisesInWorkouts = new HashSet<TrsExercisesInWorkoutDto>();
        }

        public int IdExercise { get; set; }
        public int Repetitions { get; set; }
        public int Rounds { get; set; }
        public int Prpercentage { get; set; }
        public int IdMovement { get; set; }
        public TimeSpan? RestBetweenRounds { get; set; }

        public virtual ICollection<TrsExercisesInWorkoutDto> TrsExercisesInWorkouts { get; set; }
    }
}