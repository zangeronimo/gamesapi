using System;

namespace Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; private set; }

        public DateTime? Created_at { get; set; }

        public DateTime? Updated_at { get; set; }
    }
}