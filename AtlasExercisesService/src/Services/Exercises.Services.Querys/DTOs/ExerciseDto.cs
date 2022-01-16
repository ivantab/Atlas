using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Services.Querys
{
    public class ExerciseDto
    {
        public ExerciseDto()
        {
        }

        public int IdExercise { get; set; }
        public int Repetitions { get; set; }
        public int Rounds { get; set; }
        public int Prpercentage { get; set; }
        public TimeSpan? RestBetweenRounds { get; set; }
        public MovementDto MovementDto { get; set; }

    }
}
