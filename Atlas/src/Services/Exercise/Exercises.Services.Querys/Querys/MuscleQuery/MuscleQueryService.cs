using Exercise.DataAccess.DataBase;
using Exercise.Services.Querys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Services.Querys.Querys.MuscleQuery
{
    public class MuscleQueryService : IMuscleQueryService
    {

        public readonly AtlasExerciseContext _context;

        public MuscleQueryService(AtlasExerciseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MuscleDto>> GetAllAsync()
        {
            var collection = await
                (from d in _context.Muscles
                 select new MuscleDto
                 {
                     IdMuscle = d.IdMuscle,
                     Description = d.Description,
                     LocationId = d.LocationId,
                     Name = d.Name
                 }).ToListAsync();

            return collection;
        }



        public async Task<MuscleDto> GetAsync(int Id)
        {
            MuscleDto result = new MuscleDto();
            var data = await _context.Muscles.SingleOrDefaultAsync(x => x.IdMuscle == Id);
            if (data is null)
                result = null;
            else
            {
                result = new MuscleDto()
                {
                    IdMuscle = data.IdMuscle,
                    Description = data.Description,
                    LocationId = data.LocationId,
                    Name = result.Name
                };
            }

            return result;
        }

    }
}
