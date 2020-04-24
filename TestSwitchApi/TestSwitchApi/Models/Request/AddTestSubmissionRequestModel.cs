using System.ComponentModel.DataAnnotations;

namespace TestSwitchApi.Models.Request
{
    public class AddTestSubmissionRequestModel
    {
        [Required]
        public int TestId { get; set; }
        public string TestAnswer { get; set; }
    }
}