using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Services.Proxies.Exercises.Dtos
{
    public class WorkoutProxyDto
    {
        public WorkoutProxyDto()
        {
        }

        public int IdWorkout { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ExerciseProxyDto> ExerciseDto { get; set; }
    }
}

