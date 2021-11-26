using Exercise.Services.EventHandler;
using Exercise.Services.EventHandler.Commands;
using Exercise.Services.Querys;
using Exercises.Services.Querys.Querys.LocationQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise.Api.Controllers
{
    [ApiController]
    [Route("location")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationQueryService _locationQueryService;
        private readonly IMediator _mediatr;

        public LocationController( ILocationQueryService locationQueryService, IMediator mediator , ILogger<LocationController> logger)
        {
            _logger = logger;
            _locationQueryService = locationQueryService;
            _mediatr = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<LocationDto>> GetAll()
        {
            Task<IEnumerable<LocationDto>> result; 
            try
            {
                result = _locationQueryService.GetAllAsync();
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
        public async Task<ActionResult<LocationDto>> GetAsync(int Id)
        {
            Task<LocationDto> result;
            try
            {                          
                result = _locationQueryService.GetAsync(Id);               
                if (result.Result == null)
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error no controlado la puta madre  : " + ex.Message);
            }
            _logger.LogInformation("Prueba Logs Ivan El Mas Capo");        
            return await result;
        }

        [HttpPost]
        public async Task<IActionResult> Create(LocationCreateCommand command)
        {
           await _mediatr.Publish(command);
           return CreatedAtAction("Create", new { id = command.LocationId }, command);
            //return Ok();
        }

        [HttpPut("{LocationId}")]
        public async Task<IActionResult> Update(int LocationId,LocationUpdatedCommand command)
        {
            command.LocationId = LocationId;
            await _mediatr.Publish(command);
            return NoContent();
        }

    }
}
