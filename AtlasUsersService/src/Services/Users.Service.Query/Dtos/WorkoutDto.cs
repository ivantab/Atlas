using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Services.Query.Dtos
{
    public class WorkoutDto
    {
        public WorkoutDto()
        {
        }

        public int IdWorkout { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ExerciseDto> ExerciseDto { get; set; }
    }
}

