using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O email � obrigat�rio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha � obrigat�ria")]
        public string Senha { get; set; }
    }
}