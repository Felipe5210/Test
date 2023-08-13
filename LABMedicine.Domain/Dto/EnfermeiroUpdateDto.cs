using LABMedicine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMedicine.Domain.Dto
{
    public class EnfermeiroUpdateDto
    {
        public int id { get; set; }
        public string NomeDoModelo { get; set; }
        public int IdentificadorDaColecao { get; set; }
        public string Tipo { get; set; }
        public string Layout { get; set; }
    }
}
