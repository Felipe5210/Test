using LABMedicine.Domain.Entities;
using LABMedicine.Domain.Enums;
using LABMedicine.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMedicine.Domain.Services
{
    public class EnfermeiroService : IEnfermeiroService
    {
            private readonly IEnfermeiroRepository _modeloRepository;

            public EnfermeiroService(IEnfermeiroRepository modeloRepository)
            {
                _modeloRepository = modeloRepository;
            }

            public async Task<Enfermeiro> CreateAsync(Enfermeiro modelo)
            {
                var tipo = modelo.Tipo;
                var layout = modelo.Layout;

                if (!Enum.IsDefined(typeof(TipoEnum), tipo)) throw new Exception("Tipo de estacao inválidos.");

                if (!Enum.IsDefined(typeof(LayoutEnum), layout)) throw new Exception("Layout inválidos.");

                return await _modeloRepository.CreateAsync(modelo);
            }

            public async Task<IEnumerable<Enfermeiro>> GetAllAsync(string status) => await _modeloRepository.GetAllAsync(status);

            public async Task<Enfermeiro?> GetByIdAsync(int id)
            {
                var colecao = await _modeloRepository.GetByIdAsync(id);
                if (colecao is null)  throw new KeyNotFoundException("Colecao não encontrado");

                return colecao;
            }

            public async Task UpdateStatusAsync() => await _modeloRepository.UpdateStatusAsync();

            public async Task DeleteAsync(Enfermeiro modelo) => await _modeloRepository.DeleteAsync(modelo);
    }
}
