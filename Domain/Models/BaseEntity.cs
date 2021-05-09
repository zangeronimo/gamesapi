using System;

namespace Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; private set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}