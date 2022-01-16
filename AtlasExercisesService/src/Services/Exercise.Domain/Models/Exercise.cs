using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Domain.Models
{
    public partial class Exercise
    {
        public Exercise()
        {
            TrsExercisesInWorkouts = new HashSet<TrsExercisesInWorkout>();
        }

        public int IdExercise { get; set; }
        public int Repetitions { get; set; }
        public int Rounds { get; set; }
        public int Prpercentage { get; set; }
        public int IdMovement { get; set; }
        public TimeSpan RestBetweenRounds { get; set; }

        public virtual Movement IdMovementNavigation { get; set; }
        public virtual ICollection<TrsExercisesInWorkout> TrsExercisesInWorkouts { get; set; }
    }
}
