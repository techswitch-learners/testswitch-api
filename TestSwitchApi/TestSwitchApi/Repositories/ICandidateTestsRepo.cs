using System.Collections.Generic;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;

namespace TestSwitchApi.Repositories
{
    public interface ICandidateTestsRepo
    {
        IEnumerable<CandidateTestModel> GetSubmissionsByCandidateId(int id);
        CandidateTestModel AddTestSubmission(int candidateId, AddTestSubmissionRequestModel testSubmissionModel);
    }
}