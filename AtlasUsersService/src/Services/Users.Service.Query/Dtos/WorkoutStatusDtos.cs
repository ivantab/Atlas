using System;
using System.Collections.Generic;

#nullable disable

namespace Users.Services.Query.Dtos
{
    public partial class WorkoutStatusDtos
    {
        public WorkoutStatusDtos()
        {
            UserWorkouts = new HashSet<UserWorkoutDto>();
        }

        public int IdWorkoutStatus { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserWorkoutDto> UserWorkouts { get; set; }
    }
}
