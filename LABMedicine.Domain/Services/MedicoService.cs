using LABMedicine.Domain.Entities;
using LABMedicine.Domain.Enums;
using LABMedicine.Domain.Interfaces;
using LABMedicine.Domain.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMedicine.Domain.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<Medico> CreateAsync(Medico medico)
        {
            var tipoEspecializacao = medico.EspecializacaoClinica;
            if (!Enum.IsDefined(typeof(EspecializacaoEnum), tipoEspecializacao))
            {
                throw new Exception("Tipo de especializacão inválido.");
            }
            return await _medicoRepository.CreateAsync(medico);
        }

        public async Task<IEnumerable<Medico>> GetAllAsync(string status) => await _medicoRepository.GetAllAsync(status);

        public async Task<Medico?> GetByIdAsync(int id)
        {
            var colecao = await _medicoRepository.GetByIdAsync(id);
            if (colecao is null)
                throw new KeyNotFoundException("Médico não encontrado");

            return colecao;
        }

        public async Task UpdateStatusAsync() => await _medicoRepository.UpdateStatusAsync();


        public async Task DeleteAsync(Medico medico) => await _medicoRepository.DeleteAsync(medico);
    }
}
