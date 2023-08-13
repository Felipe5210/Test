using LABMedicine.Data.Repositories;
using LABMedicine.Domain.Dto;
using LABMedicine.Domain.Entities;
using LABMedicine.Domain.Enums;
using LABMedicine.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LABMedicine.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PacienteController : Controller
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Paciente model)
        {
            try
            {
                var resultado = await _pacienteService.CreateAsync(model);
                return Ok(new { pessoa = model.nomeCompleto });
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
                return BadRequest("O status especificado é inválido. Valores validos:AGUARDANDO_ATENDIMENTO, EM_ATENDIMENTO, ATENDIDO e NAO_ATENDIDO");
            }

            var resultado = await _pacienteService.GetAllAsync(status);
            return Ok(resultado);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var paciente = await _pacienteService.GetByIdAsync(id);
                return Ok(paciente);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaciente(int id, [FromBody] PacienteUpdateDto model)
        {
            try
            {
                var paciente = await _pacienteService.GetByIdAsync(id);
                if (paciente == null)
                    return NotFound();

                if (!Enum.TryParse(typeof(StatusEnum), model.Status, true, out var _))
                    return BadRequest("O status especificado é inválido. Valores validos:AGUARDANDO_ATENDIMENTO, EM_ATENDIMENTO, ATENDIDO e NAO_ATENDIDO");

                paciente.update(model.Status);
                await _pacienteService.UpdatePacienteAsync();
                return Ok(paciente);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
