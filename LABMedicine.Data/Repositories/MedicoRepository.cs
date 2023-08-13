using LABMedicine.Domain.Entities;
using LABMedicine.Domain.Interfaces;
using LABMedicine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMedicine.Data.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly labmedicineDbContext _dbContext;

        public MedicoRepository(labmedicineDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Medico> CreateAsync(Medico medico)
        {
            _dbContext.Colecoes.Add(medico);
            await _dbContext.SaveChangesAsync();
            return medico;
        }

        public async Task<IEnumerable<Medico>> GetAllAsync(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return await _dbContext.Set<Medico>().ToListAsync();
            }
            return await _dbContext.Set<Medico>().Where(u => u.Status == status).ToListAsync();
        }

        public async Task<Medico?> GetByIdAsync(int id) => await _dbContext.Colecoes.FirstOrDefaultAsync(u => u.id == id);

        public async Task UpdateStatusAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Medico medico)
        {
            _dbContext.Remove(medico);
            await _dbContext.SaveChangesAsync();    
        }
    }
}
