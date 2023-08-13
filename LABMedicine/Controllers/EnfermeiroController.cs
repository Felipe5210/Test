using LABMedicine.Domain.Dto;
using LABMedicine.Domain.Entities;
using LABMedicine.Domain.Enums;
using LABMedicine.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LABMedicine.Api.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class EnfermeiroController : Controller
    {
        private readonly IEnfermeiroService _enfermeiroService;

        public EnfermeiroController(IEnfermeiroService enfermeiroService)
        {
            _enfermeiroService = enfermeiroService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Enfermeiro model)
        {
            try
            {
                var resultado = await _enfermeiroService.CreateAsync(model);
                return Ok(new { pessoa = model.NomeDoModelo });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> getAllmodelo(string? layout)
        {

            if (!Enum.TryParse(typeof(LayoutEnum), layout, true, out var _) && !string.IsNullOrEmpty(layout))
            {
                return BadRequest("O status especificado é inválido. Valores validos: Bordado,Estampa,Liso");
            }

            var resultado = await _enfermeiroService.GetAllAsync(layout);
            return Ok(resultado);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _enfermeiroService.GetByIdAsync(id);
                return Ok(usuario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColecao(int id, [FromBody] EnfermeiroUpdateDto model)
        {
            try
            {
                var modelo = await _enfermeiroService.GetByIdAsync(id);
                if (modelo is null) return NotFound();

                modelo.updateAll(model.NomeDoModelo, model.IdentificadorDaColecao, model.Tipo, model.Layout);
                await _enfermeiroService.UpdateStatusAsync();
                return Ok(modelo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteColecao(int id)
        {
            try
            {
                var enfermeiro = await _enfermeiroService.GetByIdAsync(id);
                if (enfermeiro is null) return NotFound();

                await _enfermeiroService.DeleteAsync(enfermeiro);
                return Ok(enfermeiro.id);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

