using static BCrypt.Net.BCrypt;

namespace Servico
{
    public class HashService
    {
        public string HashSenha(string senha)
        {
            return HashPassword(senha, GenerateSalt(8));
        }

        public bool ValidaSenha(string senha, string hash)
        {
            return Verify(senha, hash);
        }
    }
}