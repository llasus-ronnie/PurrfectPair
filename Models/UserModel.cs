using System.ComponentModel.DataAnnotations;

namespace PurrfectPair.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(50)]
        public string? Username { get; set; }

        [MaxLength(20)]
        public string? ContactNumber { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        public string? Password { get; set; } // Plain text password
    }
}



