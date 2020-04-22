using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Repositories;

namespace TestSwitchApi.Models.Response
{
    public class CandidateTestResponseModel
    {
        /*private IEnumerable<CandidateTestModel> _candidateTests;
        private readonly ICandidateTestsRepo _submissions;*/
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<CandidateTestSummary> TestSubmissions { get; set; }

        public CandidateTestResponseModel(IEnumerable<CandidateTestModel> candidateTests, CandidateDataModel candidate)
        {
            TestSubmissions = candidateTests.Select(candidateTest => new CandidateTestSummary(candidateTest));
            FirstName = candidate.FirstName;
            LastName = candidate.LastName;
        }
    }
}