using LABMedicine.Domain.Dto;
using LABMedicine.Domain.Entities;
using LABMedicine.Domain.Enums;
using LABMedicine.Domain.Interfaces;
using LABMedicine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LABMedicine.Data.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly labmedicineDbContext _dbContext;

        public PacienteRepository(labmedicineDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Paciente> CreateAsync(Paciente paciente)
        {
            _dbContext.Pacientes.Add(paciente);
            await _dbContext.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente?> GetByIdAsync(int id) => await _dbContext.Pacientes.FirstOrDefaultAsync(u => u.id == id);
        public async Task<IEnumerable<Paciente>> GetAllAsync(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return await _dbContext.Set<Paciente>().ToListAsync();
            }

            return await _dbContext.Set<Paciente>().Where(u => u.Status == status).ToListAsync();
        }

        public async Task UpdatePacienteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
