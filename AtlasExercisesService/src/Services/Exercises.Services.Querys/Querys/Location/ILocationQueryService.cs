using Exercise.Services.Querys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Services.Querys.Querys.Location
{
    public interface ILocationQueryService
    {

        Task<List<LocationDto>> GetAllAsync();

        Task<LocationDto> GetAsync(int Id);
    }
}
