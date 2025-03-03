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
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;
        private readonly IMapper _mapper;

        public ProjetoController(IProjetoService projetoService, IMapper mapper)
        {
            _projetoService = projetoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjetoResource>> GetAllAsync()
        {
            var projeto = await _projetoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Projeto>, IEnumerable<ProjetoResource>>(projeto);
            Console.WriteLine(JsonSerializer.Serialize(projeto));

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProjetoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var projeto = _mapper.Map<SaveProjetoResource, Projeto>(resource);
            var result = await _projetoService.SaveAsync(projeto);

            if (!result.Success)
                return BadRequest(result.Message);

            var projetoResource = _mapper.Map<Projeto, ProjetoResource>(result.Projeto);
            return Ok(projetoResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] SaveProjetoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var projeto = _mapper.Map<SaveProjetoResource, Projeto>(resource);
            var result = await _projetoService.UpdateAsync(id, projeto);

            if (!result.Success)
                return BadRequest(result.Message);

            var projetoResource = _mapper.Map<Projeto, ProjetoResource>(result.Projeto);
            return Ok(projetoResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _projetoService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var projetoResource = _mapper.Map<Projeto, ProjetoResource>(result.Projeto);
            return Ok(projetoResource);
        }
    }
}
