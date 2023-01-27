using Microsoft.AspNetCore.Mvc;
using MinhaDistribuidora.Models;
using MinhaDistribuidora.Business;
using MinhaDistribuidora.Data.VO;
using MinhaDistribuidora.Hypermedia.Filters;

namespace MinhaDistribuidora.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;
        private IClienteBusiness _clienteBusiness;

        public ClienteController(ILogger<ClienteController> logger, IClienteBusiness clienteBusiness)
        {
            _logger = logger;
            _clienteBusiness = clienteBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_clienteBusiness.FindAll());
          
        }

        [HttpGet("{Id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int Id)
        {
            var cliente = _clienteBusiness.FindByID(Id);
            if(cliente == null) return NotFound();
            return Ok(cliente);

        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] ClienteVO cliente)
        {
            
            if (cliente == null) return BadRequest();
            return Ok(_clienteBusiness.Create(cliente));

        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] ClienteVO cliente)
        {

            if (cliente == null) return BadRequest();
            return Ok(_clienteBusiness.Update(cliente));

        }

        [HttpDelete("{Id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int Id)
        {
            _clienteBusiness.Delete(Id);

            return NoContent();

        }
    }
}