using Exercise.Services.Querys;
using Exercises.Services.Querys.Querys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercise.Api.Controllers
{
    [Route("v1/workout")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        
        private readonly IWorkoutQueryService _workoutQueryService;
        private readonly ILogger<WorkoutController> _logger;
        public WorkoutController(IWorkoutQueryService workoutQueryService, ILogger<WorkoutController> logger)
        {
            _logger = logger;
            _workoutQueryService = workoutQueryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutDto>> GetAsync(int id)
        {
            Task<WorkoutDto> result;
            try
            {
                result = _workoutQueryService.GetAsync(id);
                if (result.Result == null || result.Result.ExerciseDto.Count == 0 || result.Result.IdWorkout == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado la puta madre  : " + ex.Message);
            }
            return await result;  
        }

    }
}
