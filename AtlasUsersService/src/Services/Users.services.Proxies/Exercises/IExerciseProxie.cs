using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Users.Services.Proxies.Exercises.Dtos;

namespace Users.Services.Proxies.Exercises
{
    public interface IExerciseProxie
    {
        Task<WorkoutProxyDto> GetWorkOutAsync(int id);
    }
}
