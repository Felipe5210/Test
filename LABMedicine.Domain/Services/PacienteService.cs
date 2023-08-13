using LABMedicine.Domain.Dto;
using LABMedicine.Domain.Entities;
using LABMedicine.Domain.Enums;
using LABMedicine.Domain.Interfaces;
using LABMedicine.Domain.utils;

namespace LABMedicine.Domain.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<Paciente> CreateAsync(Paciente paciente)
        {
            
            var documentoValido = ValidationUtils.IsCpfOrCnpjValid(paciente.CpfOuCnpj);
            if (!documentoValido)
            {
                throw new Exception("Cpf ou Cnpj inválido.");
            }

            return await _pacienteRepository.CreateAsync(paciente);
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync(string status) => await _pacienteRepository.GetAllAsync(status);

        public async Task<Paciente?> GetByIdAsync(int id )
        {
            var paciente =  await _pacienteRepository.GetByIdAsync(id);
            if (paciente is null)
                throw new KeyNotFoundException("Paciente não encontrado");

            return paciente;
        }

        public async Task UpdatePacienteAsync() => await _pacienteRepository.UpdatePacienteAsync();


    }
}
