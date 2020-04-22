using System.Collections.Generic;
using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Repositories
{
    public interface ICandidateTestsRepo
    {
        IEnumerable<CandidateTestModel> GetSubmissionsById(int Id);
    }
}