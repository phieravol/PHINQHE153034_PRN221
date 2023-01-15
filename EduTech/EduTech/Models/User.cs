using System;
using System.Collections.Generic;

namespace EduTech.Models
{
    public partial class User
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string? Fullname { get; set; }
        public int? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public byte[]? Image { get; set; }
        public DateTime? Dob { get; set; }
        public string? Company { get; set; }
    }
}
