using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fractionalized.DTOs.Subscriber
{
    public class RegisterDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Username cannot be shorter that 3")]
        public string? Password { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Username Too Short")]
        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Invalid", MinimumLength = 6)]
        public string? CryptoAddress { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}