using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Domain.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            Movements = new HashSet<Movement>();
        }

        public int IdDiscipline { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
    }
}
