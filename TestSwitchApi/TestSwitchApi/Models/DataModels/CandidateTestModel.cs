using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestSwitchApi.Models.DataModels
{
    public class CandidateTestModel
    {
        [Key]
        public int CandidateId { get; set; }
        [Key]
        public int TestId { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Example { get; set; }
        public int Number { get; set; }
        public string TestStarterCode { get; set; }
        public string InputType { get; set; }
        public string InputDescription { get; set; }
        public string Input { get; set; }
        public string OutputType { get; set; }
        public string OutputDescription { get; set; }
        public string ExpectedOutput { get; set; }
        public string? CandidateAnswer { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}