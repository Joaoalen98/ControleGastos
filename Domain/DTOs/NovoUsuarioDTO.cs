using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class NovoUsuarioDTO
    {
        [Required(ErrorMessage = "CPF é obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Senha { get; set; }
    }
}