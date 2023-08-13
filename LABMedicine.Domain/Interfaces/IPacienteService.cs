using LABMedicine.Domain.Dto;
using LABMedicine.Domain.Entities;

namespace LABMedicine.Domain.Interfaces
{
    public interface IPacienteService
    {
        Task<Paciente> CreateAsync(Paciente paciente);
        Task<IEnumerable<Paciente>> GetAllAsync(string status);

        Task UpdatePacienteAsync();

        Task<Paciente?> GetByIdAsync(int id);
    }
}
