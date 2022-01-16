using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Domain.Models
{
    public partial class Difficulty
    {
        public Difficulty()
        {
            Movements = new HashSet<Movement>();
        }

        public int IdDifficulty { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
    }
}
