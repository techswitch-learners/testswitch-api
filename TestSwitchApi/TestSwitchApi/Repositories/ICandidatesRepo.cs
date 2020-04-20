using System.Collections.Generic;
using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Repositories
{
    public interface ICandidatesRepo
    {
            IEnumerable<CandidateDataModel> GetAllCandidates();
    }
}