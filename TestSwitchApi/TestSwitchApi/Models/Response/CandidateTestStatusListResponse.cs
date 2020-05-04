using System.Collections.Generic;
using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Models.Response
{
    public class CandidateTestStatusListResponse
    {
        public CandidateDataModel Candidate { get; set; }
        public List<CandidateTestStatus> CandidateTests { get; set; }
        public CandidateTestStatusListResponse(CandidateDataModel candidateDataModel, List<CandidateTestStatus> listCandidateStatus)
        {
            CandidateTests = listCandidateStatus;
            Candidate = candidateDataModel;
        }
    }
    }