using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Models.Response
{
    public class CandidateTestStatus
    {
        public string TestName { get; set; }
        public string TestStatus { get; set; }


        public CandidateTestStatus()
        {
        }

        public CandidateTestStatus(CandidateTestModel candidateTest)
        {
            TestName = $"Test {candidateTest.TestId}";
            TestStatus = candidateTest.TestStatus;
        }
    }
}