using LABMedicine.Domain.Entities;
using LABMedicine.Domain.Interfaces;
using LABMedicine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMedicine.Data.Repositories
{
    public class ModeloRepository : IEnfermeiroRepository
    {

        private readonly labmedicineDbContext _dbContext;

        public ModeloRepository(labmedicineDbContext context)
        {
            _dbContext = context;
        }
        public async Task<Enfermeiro> CreateAsync(Enfermeiro modelo)
        {
            _dbContext.Modelos.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<IEnumerable<Enfermeiro>> GetAllAsync(string layout)
        {
            if (string.IsNullOrWhiteSpace(layout))  return await _dbContext.Set<Enfermeiro>().ToListAsync();

            return await _dbContext.Set<Enfermeiro>().Where(u => u.Layout == layout).ToListAsync();
        }

        public async Task<Enfermeiro?> GetByIdAsync(int id) => await _dbContext.Modelos.FirstOrDefaultAsync(u => u.id == id);

        public async Task UpdateStatusAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Enfermeiro modelo)
        {
            _dbContext.Remove(modelo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
