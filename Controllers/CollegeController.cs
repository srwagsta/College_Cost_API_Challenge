using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdvicentChallenge.Models;
using AdvicentChallenge.Supervisor.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

namespace AdvicentChallenge.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeSupervisor _collegeSupervisor;

        public CollegeController(ICollegeSupervisor collegeSupervisor)
        {
            this._collegeSupervisor = collegeSupervisor;
        }
        
        // GET api/colleges
        [HttpGet("colleges")]
        [Produces(typeof(IEnumerable<CollegeModel>))]
        public async Task<ActionResult<IEnumerable<CollegeModel>>> Get(CancellationToken ct = default)
        {
            try
            {
                return new ObjectResult(await this._collegeSupervisor.GetAllCollegeAsync(ct));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // GET api/college
        [HttpGet("college")]
        [Produces(typeof(CollegeViewModel))]
        public async Task<ActionResult<CollegeModel>> Get([FromBody] CollegeDataRequestDto request, CancellationToken ct = default)
        {
            if (string.IsNullOrEmpty(request.collegeName))
            {
                return BadRequest("Error: College name is required");
            }
            try
            {
                var college = await this._collegeSupervisor.GetCollegeByNameAsync(request.collegeName, ct);
                if (college == null)
                {
                    return NotFound("Error: College not found");
                }

                var collegeResponse = new CollegeViewModel
                {
                    Cost = request.roomAndBoard
                        ? college.RoomAndBoard + college.InStateTuition
                        : college.InStateTuition
                };
                 // TODO: Implement data shaping
                
                return Ok(collegeResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
   
    }
}