using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid id { get; set; }
        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }
        public DateTime? updateAt { get; set; }     
        
    }
}