using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDesafioDotnet.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        public int id { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo usuário obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo Senha obrigatório")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
