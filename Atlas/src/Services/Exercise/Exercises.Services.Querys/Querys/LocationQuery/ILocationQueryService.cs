using Exercise.Services.Querys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Services.Querys.Querys.LocationQuery
{
    public interface ILocationQueryService
    {

        Task<IEnumerable<LocationDto>> GetAllAsync();

        Task<LocationDto> GetAsync(int Id);
    }
}
