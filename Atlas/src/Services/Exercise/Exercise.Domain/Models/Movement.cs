using System;
using System.Collections.Generic;

#nullable disable

namespace Exercise.Domain.Models
{
    public partial class Movement
    {
        public Movement()
        {
            Exercises = new HashSet<Exercise>();
            TrsSecondaryMusclesInMovements = new HashSet<TrsSecondaryMusclesInMovement>();
        }

        public int IdMovement { get; set; }
        public string Name { get; set; }
        public int IdDiscipline { get; set; }
        public int MainMuscle { get; set; }
        public int IdDifficulty { get; set; }
        public string Description { get; set; }

        public virtual Discipline IdDisciplineNavigation { get; set; }
        public virtual Muscle MainMuscleNavigation { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ICollection<TrsSecondaryMusclesInMovement> TrsSecondaryMusclesInMovements { get; set; }
    }
}
