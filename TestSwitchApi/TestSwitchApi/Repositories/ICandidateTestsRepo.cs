using System.Collections.Generic;
using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Repositories
{
    public interface ICandidateTestsRepo
    {
        IEnumerable<CandidateTestModel> GetSubmissionsByCandidateId(int id);
    }
}