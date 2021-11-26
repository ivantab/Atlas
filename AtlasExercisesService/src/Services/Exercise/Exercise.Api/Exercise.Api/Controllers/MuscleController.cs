using Exercise.Services.Querys;
using Exercises.Services.Querys;
using Exercises.Services.Querys.Querys.MuscleQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Api.Controllers
{
    [ApiController]
    [Route("muscle")]
    public class MuscleController : ControllerBase
    {
        private readonly IMuscleQueryService _muscleQueryService;
        private readonly ILogger<MuscleController> _logger;
        public MuscleController(IMuscleQueryService muscleQueryService,ILogger<MuscleController> logger)
        {
            _logger = logger;
            _muscleQueryService = muscleQueryService;
        }

        [HttpGet]
        public async Task<IEnumerable<MuscleDto>> GetAll()
        {
            Task<IEnumerable<MuscleDto>> result;
            try
            {
               result = _muscleQueryService.GetAllAsync();
                if (result.Result == null)
                {
                  
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error no controlado la puta madre  : " + ex.Message);
            }
            return await result;
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<MuscleDto>> Get(int Id)
        {
            Task<MuscleDto> result = null;
            try
            {              
                result = _muscleQueryService.GetAsync(Id);
                if(result.Result == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error no controlado la puta madre  : " + ex.Message); ;
            }
       
            return await result;
        }
    }
}
