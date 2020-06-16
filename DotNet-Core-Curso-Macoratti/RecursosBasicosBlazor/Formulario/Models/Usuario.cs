using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Formulario.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe um nome")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Range(18, 80, ErrorMessage = "Idade deve ser entre {0} e {1}")]
        public int Idade { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Escolha um status válido")]
        public string Status { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} \tNome:{Nome} \tEmail:{Email} \tIdade: {Idade} \tStatus: {Status}";
        }
    }
}
