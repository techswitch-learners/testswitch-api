using System.ComponentModel.DataAnnotations;

namespace TestSwitchApi.Models.Request
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        [StringLength(128)]
        public string Email { get; set; }
        [Required]
        [StringLength(128)]
        public string Password { get; set; }
    }
}