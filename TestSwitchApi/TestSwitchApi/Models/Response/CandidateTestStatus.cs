using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Models.Response
{
    public class CandidateTestStatus
    {
        public string TestName { get; set; }
        public string TestStatus { get; set; }

        private enum Status
        {
            NotCompleted,
            Completed,
        }

        public CandidateTestStatus()
        {
        }

        public CandidateTestStatus(CandidateTestModel candidateTest)
        {
            TestName = $"Test {candidateTest.TestId}";
            TestStatus = candidateTest.EndTime == null?Status.Completed.ToString() : Status.NotCompleted.ToString();
        }
    }
}