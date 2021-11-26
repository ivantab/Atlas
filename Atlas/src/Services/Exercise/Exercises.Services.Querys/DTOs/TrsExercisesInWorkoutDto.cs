using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Services.Querys
{
    public class TrsExercisesInWorkoutDto
    {
        public int IdExerciseWorkout { get; set; }
        public int IdWorkout { get; set; }
        public int IdExercise { get; set; }

        public virtual ExerciseDto IdExerciseNavigation { get; set; }
        public virtual WorkoutDto IdWorkoutNavigation { get; set; }
    }
}
