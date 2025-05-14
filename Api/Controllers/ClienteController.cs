using Infra.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> All()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> ById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Cliente cliente)
        {
            try
            {
                await _clienteService.AddAsync(cliente);
                return CreatedAtAction(nameof(ById), new { id = cliente.Id }, cliente);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Cliente cliente)
        {
            try
            {
                await _clienteService.UpdateAsync(cliente);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clienteService.DeleteAsync(id);
            return NoContent();
        }
    }
}
