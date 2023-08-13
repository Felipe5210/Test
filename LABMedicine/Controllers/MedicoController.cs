using LABMedicine.Domain.Dto;
using LABMedicine.Domain.Entities;
using LABMedicine.Domain.Enums;
using LABMedicine.Domain.Interfaces;
using LABMedicine.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace LABMedicine.Api.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class MedicoController : Controller
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Medico model)
        {
            try
            {
                var resultado = await _medicoService.CreateAsync(model);
                return Ok(new { pessoa = model.NomeDaColecao });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> getAllPessoa(string? status)
        {

            if (!Enum.TryParse(typeof(StatusEnum), status, true, out var _) && !string.IsNullOrEmpty(status))
            {
                return BadRequest("O status especificado é inválido. Valores validos: Ativo e Inativo");
            }

            var resultado = await _colecaoService.GetAllAsync(status);
            return Ok(resultado);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _colecaoService.GetByIdAsync(id);
                return Ok(usuario);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("status/{id}")]
        public async Task<IActionResult> UpdateColecaoStatus(int id, [FromBody] MedicoStatusUpdateDto model)
        {
            try
            {
                var colecao = await _colecaoService.GetByIdAsync(id);
                if (colecao == null)
                    return NotFound();

                if (!Enum.TryParse(typeof(StatusEnum), model.Status, true, out var _))
                    return BadRequest("O status especificado é inválido. Valores validos: Ativo e Inativo");

                colecao.update(model.Status);
                await _colecaoService.UpdateStatusAsync();
                return Ok(colecao);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColecao(int id, [FromBody] ColecaoUpdateDto model)
        {
            try
            {
                var colecao = await _colecaoService.GetByIdAsync(id);
                if (colecao is null) return NotFound();

                colecao.updateAll(model.NomeDaColecao, model.idResponsavel, model.Marca, model.Orcamento, model.AnoDeLancamento, model.estacao, model.Status);
                await _colecaoService.UpdateStatusAsync();
                return Ok(colecao);
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
                var colecao = await _colecaoService.GetByIdAsync(id); 
                if (colecao is null) return NotFound();
               
                await _colecaoService.DeleteAsync(colecao);
                return Ok(colecao.id);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
