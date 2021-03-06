using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}