using System.ComponentModel.DataAnnotations;

namespace TestSwitchApi.Models.Request
{
    public class AddTestSubmissionRequestModel
    {
        [Required]
        public int TestId { get; set; }
        [Required]
        public string CandidateAnswer { get; set; }
    }
}