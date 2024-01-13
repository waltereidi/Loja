
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Dominio.loja.Entity;
using System.ComponentModel.DataAnnotations;

namespace Dominio.loja.DTO.Requests
{
    public class LoginRequest
    {
        [Required]
        public string? Login { get; set; }
        [Required]
        public string? Password { get; set; }

    }
  



}
