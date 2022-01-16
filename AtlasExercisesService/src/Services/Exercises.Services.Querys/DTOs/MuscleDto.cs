using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Services.Querys
{
    public class MuscleDto
    {
        public MuscleDto()
        {
        }

        public int IdMuscle { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationDto Location { get; set; }

    }
}
