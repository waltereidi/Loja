using System.ComponentModel.DataAnnotations;

namespace Dominio.loja.Dto.Requests
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
