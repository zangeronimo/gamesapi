using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 150 caracteres")]
        [MaxLength(150, ErrorMessage = "Este campo deve conter entre 3 e 150 caracteres")]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 150 caracteres")]
        [MaxLength(150, ErrorMessage = "Este campo deve conter entre 3 e 150 caracteres")]
        public string Email { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}