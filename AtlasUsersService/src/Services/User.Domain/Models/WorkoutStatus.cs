using System;
using System.Collections.Generic;

#nullable disable

namespace User.Domain.Models
{
    public partial class WorkoutStatus
    {
        public WorkoutStatus()
        {
            UserWorkouts = new HashSet<UserWorkout>();
        }

        public int IdWorkoutStatus { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserWorkout> UserWorkouts { get; set; }
    }
}
