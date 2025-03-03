using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Services;

namespace Trabalho_Web_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Contato>> GetAllAsync()
        {
            var contato = await _contatoService.ListAsync();

            Console.WriteLine(contato);

            return contato;
        }


    }
}
