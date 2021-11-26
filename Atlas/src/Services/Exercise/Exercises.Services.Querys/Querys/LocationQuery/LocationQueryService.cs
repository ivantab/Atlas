using Exercise.DataAccess.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exercise.Services.Querys;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Exercises.Services.Querys.Querys.LocationQuery
{
    public class LocationQueryService : ILocationQueryService
    {
        public readonly AtlasExerciseContext _context;

        public LocationQueryService(AtlasExerciseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LocationDto>> GetAllAsync()
        {
            var collection = await (from d in _context.Locations select new LocationDto
            {
                LocationId = d.LocationId,
                Description = d.Description,
                Ubication = d.Ubication,                 
            }).ToListAsync();

            return collection;
        }

        public async Task<LocationDto> GetAsync(int Id)
        {
            LocationDto result = new LocationDto();
            var data = await _context.Locations.SingleOrDefaultAsync(x => x.LocationId == Id);
            if (data == null)
                result = null;
            else
            {
                result = new LocationDto()
                {
                    LocationId = data.LocationId,
                    Description = data.Description,
                    Ubication = data.Ubication,                                      
                };
            }
            return result;
        }
    }
}
