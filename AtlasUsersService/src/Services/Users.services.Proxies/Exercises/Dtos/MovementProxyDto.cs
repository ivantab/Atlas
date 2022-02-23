namespace Users.Services.Proxies.Exercises.Dtos
{
    public class MovementProxyDto
    {
        public MovementProxyDto()
        {
        }

        public int IdMovement { get; set; }
        public string Name { get; set; }
        public DisciplineProxyDto Discipline { get; set; }
        public MuscleProxyDto MainMuscle { get; set; }
        public DifficultyProxyDto Difficulty { get; set; }
        public string Description { get; set; }

    }
}