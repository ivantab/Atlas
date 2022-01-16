using System;
using System.Collections.Generic;

#nullable disable

namespace User.Domain.Models
{
    public partial class UserWorkout
    {
        public int IdUserWorkout { get; set; }
        public int IdUser { get; set; }
        public int IdWorkout { get; set; }
        public int IdWorkoutStatus { get; set; }
        public int Progress { get; set; }

        public virtual WorkoutStatus IdWorkoutStatusNavigation { get; set; }
    }
}
