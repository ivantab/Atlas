using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.services.Proxies.Exercises.Dtos;

namespace Users.Services.Proxies.Exercises
{
    public interface IExerciseProxie
    {
        Task<WorkoutDto> GetWorkOutAsync(int id);
    }
}
