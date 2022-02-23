using System;

namespace Users.Services.Proxies.Exercises.Dtos
{
    public class ExerciseProxyDto
    {
        public ExerciseProxyDto()
        {
        }

        public int IdExercise { get; set; }
        public int Repetitions { get; set; }
        public int Rounds { get; set; }
        public int Prpercentage { get; set; }
        public TimeSpan? RestBetweenRounds { get; set; }
        public MovementProxyDto MovementDto { get; set; }

    }
}