using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Services.Querys
{
    public class DisciplineDto
    {
        public DisciplineDto()
        {
            Movements = new HashSet<MovementDto>();
        }

        public int IdDiscipline { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovementDto> Movements { get; set; }
    }
}
