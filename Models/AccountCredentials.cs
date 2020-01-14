using System.ComponentModel.DataAnnotations;

namespace jwtnetcore31.Models {
    public class AccountCredentials {
        
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}