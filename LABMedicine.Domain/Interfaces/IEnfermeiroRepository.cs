using LABMedicine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMedicine.Domain.Interfaces
{
    public interface IEnfermeiroRepository
    {
        Task<Enfermeiro> CreateAsync(Enfermeiro enfermeiro);
        Task<IEnumerable<Enfermeiro>> GetAllAsync(string status);
        Task<Enfermeiro?> GetByIdAsync(int id);
        Task UpdateStatusAsync();
        Task DeleteAsync(Enfermeiro enfermeiro);
    }
}
