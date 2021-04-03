using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é um campo obrigatório para o Login.")]
        [EmailAddress(ErrorMessage = "Email com formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {0} caracteres.")]
        public string Email { get; set; }
    }
}