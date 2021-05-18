using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDesafioNet.Models
{
    public class import
    {
        public int Tipo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string CPF { get; set; }
        public string Cartao { get; set; }
        public string Hora { get; set; }
        public string DonoLoja { get; set; }
        public string NomeLoja { get; set; }

    }
}
