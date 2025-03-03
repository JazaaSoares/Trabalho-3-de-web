using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Trabalho_Web_3.Domains.Models;
using Trabalho_Web_3.Domains.Services;
using Trabalho_Web_3.Extension;
using Trabalho_Web_3.Resources;

namespace Trabalho_Web_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;

        public ContatoController(IContatoService contatoService, IMapper mapper)
        {
            _contatoService = contatoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContatoResource>> GetAllAsync()
        {
            var contato = await _contatoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Contato>, IEnumerable<ContatoResource>>(contato);
            Console.WriteLine(JsonSerializer.Serialize(contato));

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveContatoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var contato = _mapper.Map<SaveContatoResource, Contato>(resource);
            var result = await _contatoService.SaveAsync(contato);

            if (!result.Success)
                return BadRequest(result.Message);

            var contatoResource = _mapper.Map<Contato, ContatoResource>(result.Contato);
            return Ok(contatoResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] SaveContatoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var contato = _mapper.Map<SaveContatoResource, Contato>(resource);
            var result = await _contatoService.UpdateAsync(id, contato);

            if (!result.Success)
                return BadRequest(result.Message);

            var contatoResource = _mapper.Map<Contato, ContatoResource>(result.Contato);
            return Ok(contatoResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _contatoService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var contatoResource = _mapper.Map<Contato, ContatoResource>(result.Contato);
            return Ok(contatoResource);
        }
    }
}
