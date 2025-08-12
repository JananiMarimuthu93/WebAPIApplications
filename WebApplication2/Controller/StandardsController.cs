using CodeFirstApproach.Interface;
using CodeFirstApproach.Repository;
using CodeFirstApproach.Service;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace CodeFirstApproach.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardsController:ControllerBase
    {
        private readonly  IStandardRepository _service;

        public StandardsController(IStandardRepository service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Standard>> GetAllStandards()
        {
            return (IEnumerable<Standard>)await _service.GetAllStandards();
        }
        [HttpGet("id")]
        public async Task<Standard> GetStandardById(int id)
        {
            return await _service.GetStandardById(id);
        }

    }
}
