using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}