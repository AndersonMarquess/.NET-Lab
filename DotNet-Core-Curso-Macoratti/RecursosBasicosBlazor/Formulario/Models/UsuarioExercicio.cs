using System;
using System.ComponentModel.DataAnnotations;

namespace Formulario.Models
{
    public class UsuarioExercicio
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Obrigatório")]
        [StringLength(10, ErrorMessage = "Máximo de 10 caracteres")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Obrigatório")]
        [StringLength(10, ErrorMessage = "Máximo de 10 caracteres")]
        public string Sobrenome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Obrigatório")]
        [Range(18, 100, ErrorMessage = "A Idade deve estar entre 18 e 100")]
        public int Idade { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Obrigatório")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "O campo deve estar entre 4 e 10 caracteres")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Obrigatório")]
        [EmailAddress(ErrorMessage = "Formato inválido")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Obrigatório")]
        public string Perfil { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Obrigatório")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "O campo deve estar entre 8 e 10 caracteres")]
        public string Password { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Obrigatório")]
        [Compare("Password", ErrorMessage = "Senhas diferentes")]
        public string ConfirmaPassword { get; set; } = string.Empty;


        public override string ToString()
        {
            return $"{Nome} - {Sobrenome} - {Idade} - {Login} - {Email} - {Perfil} - {Password} - {ConfirmaPassword}";
        }
    }
}
