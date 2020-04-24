using System.ComponentModel.DataAnnotations;

namespace TestSwitchApi.Models.Request
{
    public class CandidateRequest
    {
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(128)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(128)]
        public string Email { get; set; }
    }
}