using Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio_Legal.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(){
            return Ok(
                new List<Cliente>(){
                    new Cliente{
                        Id=1,
                        Nome="Rangerson Clemente",
                        DataNascimento = new DateTime(2003,05,31)
                    },
                    new Cliente{
                        Id=2,
                        Nome="Romaldo Clemente",
                        DataNascimento = new DateTime(2005,07,30)
                    }
            });
        }

        [HttpGet("{id}")]
        public string Get(int id){
            return "Cliente1";
        }

        [HttpPost]
        public void Post([FromBody] string cliente){
        }

        [HttpPut("{idCliente}")]
        public void Put(int idCliente, [FromBody] string cliente){

        }

        [HttpDelete("{id}")]
        public void Delete(int id){
            
        }
    }
}
