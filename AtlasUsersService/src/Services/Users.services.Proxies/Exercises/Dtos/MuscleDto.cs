namespace Users.services.Proxies.Exercises.Dtos
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