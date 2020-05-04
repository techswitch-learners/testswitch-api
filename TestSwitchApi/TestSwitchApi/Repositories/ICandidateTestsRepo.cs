using System.Collections.Generic;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;
using TestSwitchApi.Models.Response;

namespace TestSwitchApi.Repositories
{
    public interface ICandidateTestsRepo
    {
        IEnumerable<CandidateTestModel> GetSubmissionsByCandidateId(int id);
        CandidateTestModel AddTestSubmission(int candidateId, AddTestSubmissionRequestModel testSubmissionModel);
        CandidateTestStatus GetCandidateTestStatus(int candidateId, string testName);
    }
}