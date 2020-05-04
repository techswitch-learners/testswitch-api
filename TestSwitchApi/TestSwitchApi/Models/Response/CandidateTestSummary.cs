using System;
using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Models.Response
{
    public class CandidateTestSummary
    {
        public int TestId { get; set; }
        public string CandidateAnswer { get; set; }

        public TimeSpan? TimeTaken { get; set; }

        public CandidateTestSummary(CandidateTestModel candidateTest)
        {
            TestId = candidateTest.TestId;
            CandidateAnswer = candidateTest.CandidateAnswer;
            TimeTaken = candidateTest.EndTime - candidateTest.StartTime;
        }
    }
}
