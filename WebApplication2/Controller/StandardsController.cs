using CodeFirstApproach.Interface;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace CodeFirstApproach.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardsController : ControllerBase
    {
        private readonly IStandardRepository _service;

        public StandardsController(IStandardRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Standard>>> GetAllStandards()
        {
            var standards = await _service.GetAllStandards();
            return Ok(standards);
        }

 
        [HttpGet("{id}")]
        public async Task<ActionResult<Standard>> GetStandardById(int id)
        {
            var standard = await _service.GetStandardById(id);
            if (standard == null)
            {
                return NotFound($"Standard with ID {id} not found.");
            }
            return Ok(standard);
        }


        [HttpPost]
        public async Task<ActionResult<Standard>> AddStandard(Standard standard)
        {
            var createdStandard = await _service.AddStandard(standard);
            return CreatedAtAction(nameof(GetStandardById), new { id = createdStandard.StandardId }, createdStandard);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Standard>> UpdateStandard(int id, Standard standard)
        {
            var updatedStandard = await _service.UpdateStandard(id, standard);
            if (updatedStandard == null)
            {
                return NotFound($"Standard with ID {id} not found.");
            }
            return Ok(updatedStandard);
        }

 
        [HttpDelete("{id}")]
        public async Task<ActionResult<Standard>> DeleteStandard(int id)
        {
            var deletedStandard = await _service.DeleteStandard(id);
            if (deletedStandard == null)
            {
                return NotFound($"Standard with ID {id} not found.");
            }
            return Ok(deletedStandard);
        }
    }
}
