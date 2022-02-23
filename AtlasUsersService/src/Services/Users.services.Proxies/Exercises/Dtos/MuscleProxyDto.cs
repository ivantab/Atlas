namespace Users.Services.Proxies.Exercises.Dtos
{
    public class MuscleProxyDto
    {
        public MuscleProxyDto()
        {
        }

        public int IdMuscle { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationProxyDto Location { get; set; }

    }
}