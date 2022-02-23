namespace Users.Services.Query.Dtos
{
    public class MovementDto
    {
        public MovementDto()
        {
        }

        public int IdMovement { get; set; }
        public string Name { get; set; }
        public DisciplineDto Discipline { get; set; }
        public MuscleDto MainMuscle { get; set; }
        public DifficultyDto Difficulty { get; set; }
        public string Description { get; set; }

    }
}