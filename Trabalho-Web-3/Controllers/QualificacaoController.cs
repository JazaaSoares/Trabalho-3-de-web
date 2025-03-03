using AutoMapper;
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
    public class QualificacaoController : ControllerBase
    {
        private readonly IQualificacaoService _qualificacaoService;
        private readonly IMapper _mapper;

        public QualificacaoController(IQualificacaoService qualificacaoService, IMapper mapper)
        {
            _qualificacaoService = qualificacaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<QualificacaoResource>> GetAllAsync()
        {
            var qualificacao = await _qualificacaoService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Qualificacao>, IEnumerable<QualificacaoResource>>(qualificacao);
            Console.WriteLine(JsonSerializer.Serialize(qualificacao));

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveQualificacaoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var qualificacao = _mapper.Map<SaveQualificacaoResource, Qualificacao>(resource);
            var result = await _qualificacaoService.SaveAsync(qualificacao);

            if (!result.Success)
                return BadRequest(result.Message);

            var qualificacaoResource = _mapper.Map<Qualificacao, QualificacaoResource>(result.Qualificacao);
            return Ok(qualificacaoResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] SaveQualificacaoResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var qualificacao = _mapper.Map<SaveQualificacaoResource, Qualificacao>(resource);
            var result = await _qualificacaoService.UpdateAsync(id, qualificacao);

            if (!result.Success)
                return BadRequest(result.Message);

            var qualificacaoResource = _mapper.Map<Qualificacao, QualificacaoResource>(result.Qualificacao);
            return Ok(qualificacaoResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _qualificacaoService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var qualificacaoResource = _mapper.Map<Qualificacao, QualificacaoResource>(result.Qualificacao);
            return Ok(qualificacaoResource);
        }
    }
}
