using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Services.Querys
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
