using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fractionalized.DTOs.Subscriber
{
    public class RegisterDTO
    {
        public required string Password { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Username cannot be shorter that 3")]
        public required string Username { get; set; }
        public required string Name { get; set; }
        public int Balance { get; set; } = 0;
        public int Spent { get; set; } = 0;
        public string CryptoAddress { get; set; } = "";

        public DateTime CreatedAt { get; set; }
    }
}