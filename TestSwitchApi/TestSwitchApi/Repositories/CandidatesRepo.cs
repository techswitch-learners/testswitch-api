using System.Collections.Generic;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Repositories
{
    public class CandidatesRepo : ICandidatesRepo
    {
        private readonly TestSwitchDbContext _context;

        public CandidatesRepo(TestSwitchDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CandidateDataModel> GetAllCandidates()
        {
            return _context.Candidates;
        }
    }
}