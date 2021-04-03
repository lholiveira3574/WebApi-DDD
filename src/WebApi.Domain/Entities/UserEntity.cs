using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório.")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório.")]
        [EmailAddress(ErrorMessage = "Email com formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }
    }
}