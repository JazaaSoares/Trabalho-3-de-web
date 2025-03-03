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
    public class ExperienciaController : ControllerBase
    {

        private readonly IExperienciaService _experienciaService;
        private readonly IMapper _mapper;

        public ExperienciaController(IExperienciaService experienciaService, IMapper mapper)
        {
            _experienciaService = experienciaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ExperienciaResource>> GetAllAsync()
        {
            var experiencia = await _experienciaService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Experiencia>, IEnumerable<ExperienciaResource>>(experiencia);
            Console.WriteLine(JsonSerializer.Serialize(experiencia));

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveExperienciaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var experiencia = _mapper.Map<SaveExperienciaResource, Experiencia>(resource);
            var result = await _experienciaService.SaveAsync(experiencia);

            if (!result.Success)
                return BadRequest(result.Message);

            var experienciaResource = _mapper.Map<Experiencia, ExperienciaResource>(result.Experiencia);
            return Ok(experienciaResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, [FromBody] SaveExperienciaResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var experiencia = _mapper.Map<SaveExperienciaResource, Experiencia>(resource);
            var result = await _experienciaService.UpdateAsync(id, experiencia);

            if (!result.Success)
                return BadRequest(result.Message);

            var experienciaResource = _mapper.Map<Experiencia, ExperienciaResource>(result.Experiencia);
            return Ok(experienciaResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _experienciaService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var experienciaResource = _mapper.Map<Experiencia, ExperienciaResource>(result.Experiencia);
            return Ok(experienciaResource);
        }
    }
}

