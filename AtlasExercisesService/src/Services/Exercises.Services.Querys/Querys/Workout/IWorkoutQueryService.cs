using Exercise.DataAccess.DataBase;
using Exercise.Services.Querys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Services.Querys.Querys
{
    public interface IWorkoutQueryService
    {
        Task<WorkoutDto> GetAsync(int id);
  
    }
}
