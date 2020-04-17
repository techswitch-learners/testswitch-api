using System.Collections.Generic;
using TestSwitchApi.DataModels;

namespace TestSwitchApi.Repositories
{
    public interface ICandidatesRepo
    {
            IEnumerable<CandidateDataModel> GetAllCandidates();
    }
}