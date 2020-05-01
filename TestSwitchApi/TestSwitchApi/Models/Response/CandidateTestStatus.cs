using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Models.Response
{
    public class CandidateTestStatus
    {
        public string TestName { get; set; }
        public Status TestStatus { get; set; }

        public enum Status
        {
            NotCompleted,
            Completed,
        }

        public CandidateTestStatus(CandidateTestModel candidateTest)
        {
            TestName = $"Test {candidateTest.TestId}";
            TestStatus = candidateTest.EndTime == null?Status.NotCompleted : Status.Completed;
        }
    }
}