using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesafioDotnet.Models
{
    [Table("datadesafio")]
    public class importFile
    {
        [Key]
        public int id { get; set; }
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
