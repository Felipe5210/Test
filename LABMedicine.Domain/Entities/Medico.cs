using LABMedicine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMedicine.Domain.Entities
{
    public class Medico : Pessoa
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O campo CRM/UF é obrigatório")]
        public string CrmUf { get; set; }
        
        [Required(ErrorMessage = "O campo idResponsavel é obrigatório")]
        public int idResponsavel { get; set; }
        
        [Required(ErrorMessage = "O campo Instutuição de Ensino é obrigatório")]
        public string InstituicaoEnsino { get; set; }
        
        [Required(ErrorMessage = "O campo Orcamento é obrigatório")]
        public decimal Orcamento { get; set; }
        
        [Required(ErrorMessage = "O campo AnoDeLancamento é obrigatório")]
        public DateTime AnoDeLancamento { get; set; }
        
        [Required(ErrorMessage = "O campo estacao é obrigatório")]
        [EnumDataType(typeof(EspecializacaoEnum))]
        public string EspecializacaoClinica { get; set; }
       
        [Required(ErrorMessage = "O campo Status é obrigatório")]
        [EnumDataType(typeof(StatusEnum))]
        public string Status { get; set; }


        public void update(string status)
        {
            Status = status;
        }

        public void updateAll(string crmUf, int IdResponsavel, string instituicaoEnsino, decimal orcamento, DateTime anoLancamento, string especializacaoClinica, string status)
        {
            InstituicaoEnsino = instituicaoEnsino;
            Orcamento = orcamento;
            CrmUf = crmUf;
            idResponsavel = idResponsavel;
            AnoDeLancamento= anoLancamento;
            EspecializacaoClinica = especializacaoClinica;
            Status = status;
        }
    }
}
