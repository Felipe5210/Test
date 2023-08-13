using LABMedicine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMedicine.Domain.Interfaces
{
    public interface IMedicoRepository
    {
        Task<Medico> CreateAsync(Medico medico);

        Task<IEnumerable<Medico>> GetAllAsync(string status);

        Task<Medico?> GetByIdAsync(int id);

        Task UpdateStatusAsync();

        Task DeleteAsync(Medico medico);
    }
}
