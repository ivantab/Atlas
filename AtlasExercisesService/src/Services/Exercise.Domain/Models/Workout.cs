using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Domain.Models
{
    public partial class Workout
    {
        public Workout()
        {
            TrsExercisesInWorkouts = new HashSet<TrsExercisesInWorkout>();
        }

        public int IdWorkout { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<TrsExercisesInWorkout> TrsExercisesInWorkouts { get; set; }
    }
}
