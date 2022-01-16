using Exercise.Services.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Services.Querys.Querys.Muscle
{
    public interface IMuscleQueryService
    {
        Task<IEnumerable<MuscleDto>> GetAllAsync();

        Task<MuscleDto> GetAsync(int Id);
    }
}
