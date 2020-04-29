    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using TestSwitchApi.Models.DataModels;
    using TestSwitchApi.Repositories;

    namespace TestSwitchApi.Models.Response
    {
        public class CandidateTestStatusResponseModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public IEnumerable<CandidateTestStatus> TestStatuses { get; set; }

            public CandidateTestStatusResponseModel(IEnumerable<CandidateTestModel> candidateTests, CandidateDataModel candidate)
            {
                TestStatuses = candidateTests.Select(candidateTest => new CandidateTestStatus(candidateTest));
                FirstName = candidate.FirstName;
                LastName = candidate.LastName;
            }
        }
    }
