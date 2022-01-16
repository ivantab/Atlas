using System;
using System.Collections.Generic;

#nullable disable

namespace Users.Services.Query.Dtos
{
    public partial class UserWorkoutDto
    {
        public int IdUserWorkout { get; set; }
        public int IdUser { get; set; }
        public int IdWorkout { get; set; }
        public int IdWorkoutStatus { get; set; }
        public int Progress { get; set; }

        public virtual WorkoutStatusDtos IdWorkoutStatusNavigation { get; set; }
    }
}
