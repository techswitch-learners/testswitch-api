using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Models.Response
{
    public class CandidateTestSummary
    {
        public int TestId { get; set; }
        public string CandidateAnswer { get; set; }

        public CandidateTestSummary()
        {
        }

        public CandidateTestSummary(CandidateTestModel candidateTest)
        {
            TestId = candidateTest.TestId;
            CandidateAnswer = candidateTest.CandidateAnswer;
        }
    }
}
