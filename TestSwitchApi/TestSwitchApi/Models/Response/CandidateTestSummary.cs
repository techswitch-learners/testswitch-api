using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Models.Response
{
    public class CandidateTestSummary
    {
        public int TestId { get; set; }
        public string TestResult { get; set; }
        public string TestAnswer { get; set; }

        public CandidateTestSummary()
        {
        }

        public CandidateTestSummary(CandidateTestModel candidateTest)
        {
            TestId = candidateTest.TestId;
            TestResult = candidateTest.TestResult;
            TestAnswer = candidateTest.TestAnswer;
        }
    }
}