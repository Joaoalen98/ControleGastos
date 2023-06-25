using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class NovoUsuarioDTO
    {
        [Required(ErrorMessage = "CPF � obrigat�rio")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Nome � obrigat�rio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email � obrigat�rio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha � obrigat�rio")]
        public string Senha { get; set; }
    }
}