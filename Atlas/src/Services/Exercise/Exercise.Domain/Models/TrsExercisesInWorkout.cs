using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Domain.Models
{
    public partial class TrsExercisesInWorkout
    {
        public int IdExerciseWorkout { get; set; }
        public int IdWorkout { get; set; }
        public int IdExercise { get; set; }

        public virtual Exercise IdExerciseNavigation { get; set; }
        public virtual Workout IdWorkoutNavigation { get; set; }
    }
}
