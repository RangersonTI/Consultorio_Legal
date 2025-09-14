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

        /// <summary>
        ///  Retorna todos os clientes cadastrados na base de dados.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await clienteManager.GetClientesAsync());
        }

        /// <summary>
        ///     Retorna o cliente com base no Id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await clienteManager.GetClienteByIdAsync(id));
        }

        /// <summary>
        ///     Cadastra um novo cliente!
        /// </summary>
        /// <param name="novoCliente"></param>
        [HttpPost]
        public async Task<IActionResult> Post(NovoCliente novoCliente)
        {
            var clienteInserido = await clienteManager.InsertClienteAsync(novoCliente);
            return CreatedAtAction(nameof(Get), new { id = clienteInserido.Id }, clienteInserido);
        }

        /// <summary>
        ///     Edita um cliente existente!
        /// </summary>
        /// <param name="cliente"></param>
        [HttpPut("{idCliente}")]
        public async Task<IActionResult> Put(AlteraCliente cliente)
        {
            var clienteAtualizado = await clienteManager.UpdateClienteAsync(cliente);

            if (clienteAtualizado == null)
            {
                return NotFound();
            }

            return Ok(clienteAtualizado);
        }

        /// <summary>
        ///     Apaga o cliente com base no Id informado!
        /// </summary>
        /// <param name="id" example="1"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await clienteManager.DeleteClienteAsync(id);
            return NoContent();

        }
    }
}
