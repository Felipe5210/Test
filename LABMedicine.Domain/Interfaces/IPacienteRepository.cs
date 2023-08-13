using LABMedicine.Domain.Dto;
using LABMedicine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMedicine.Domain.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente> CreateAsync(Paciente paciente);
        Task<IEnumerable<Paciente>> GetAllAsync(string status);
        Task UpdatePacienteAsync();

        Task<Paciente?> GetByIdAsync(int id);
    }
}
