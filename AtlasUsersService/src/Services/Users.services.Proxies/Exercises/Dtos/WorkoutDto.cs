using System;
using System.Collections.Generic;
using System.Text;

namespace Users.services.Proxies.Exercises.Dtos
{
    public class WorkoutDto
    {
        public WorkoutDto()
        {
            TrsExercisesInWorkouts = new HashSet<TrsExercisesInWorkoutDto>();
        }

        public int IdWorkout { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<TrsExercisesInWorkoutDto> TrsExercisesInWorkouts { get; set; }
    }
}

