using System.Threading.Tasks;
using Core.Domain;
using Core.Shared.ModelViews;
using Manager;
using Manager.Validator;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio_Legal.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteManager clienteManager;

        public ClientesController(IClienteManager clienteManager)
        {
            this.clienteManager = clienteManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await clienteManager.GetClientesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await clienteManager.GetClienteByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(NovoCliente novoCliente)
        {
            var clienteInserido = await clienteManager.InsertClienteAsync(novoCliente);
            return CreatedAtAction(nameof(Get), new{ id = clienteInserido.Id },clienteInserido);
        }

        [HttpPut("{idCliente}")]
        public async Task<IActionResult> Put(AlteraCliente cliente)
        {
            var clienteAtualizado = await clienteManager.UpdateClienteAsync(cliente);
            
            if(clienteAtualizado == null)
            {
                return NotFound();
            }

            return Ok(clienteAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await clienteManager.DeleteClienteAsync(id);
            return NoContent();

        }
    }
}
