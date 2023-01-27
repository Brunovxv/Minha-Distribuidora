using Microsoft.AspNetCore.Mvc;
using MinhaDistribuidora.Models;
using MinhaDistribuidora.Business;
using MinhaDistribuidora.Data.VO;

namespace MinhaDistribuidora.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly ILogger<ProdutoController> _logger;
        private IProdutoBusiness _produtoBusiness;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoBusiness produtoBusiness)
        {
            _logger = logger;
            _produtoBusiness = produtoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_produtoBusiness.FindAll());
          
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int ID)
        {
            var produto = _produtoBusiness.FindByID(ID);
            if(produto == null) return NotFound();
            return Ok(produto);

        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoVO produto)
        {
            
            if (produto == null) return BadRequest();
            return Ok(_produtoBusiness.Create(produto));

        }

        [HttpPut]
        public IActionResult Put([FromBody] ProdutoVO produto)
        {

            if (produto == null) return BadRequest();
            return Ok(_produtoBusiness.Update(produto));

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _produtoBusiness.Delete(Id);

            return NoContent();

        }
    }
}