using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Services.Query.Dtos;
using Users.Services.Query.Querys.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User.Api.Controllers
{
    [Route("v1/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserQueryService _userQueryService;

        public UserController(ILogger<UserController> logger, IUserQueryService userQueryService)
        {
            _logger = logger;
            _userQueryService = userQueryService;

        }

        [HttpGet("{id}")]
        [Route("GetAsync")]
        public async Task<ActionResult<UserDto>> GetAsync(int id)
        {
            Task<UserDto> result;
            try
            {
                result = _userQueryService.GetAsync(id);
                if (result.Result == null)
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

        [HttpGet("{id}")]
        [Route("GetWorkoutSubscribedByUserId")]
        public async Task<ActionResult<UserDto>> GetWorkoutSubscribedByUserId(int id)
        {
            Task<UserDto> result;
            try
            {
                result = _userQueryService.GetAsync(id);
                if (result.Result == null)
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

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
