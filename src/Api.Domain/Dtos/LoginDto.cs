using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é campo obrigatório para Login")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(100, ErrorMessage = "Email dever ter no maximo {1} caracteres")]
        public string email { get; set; }
    }
}
