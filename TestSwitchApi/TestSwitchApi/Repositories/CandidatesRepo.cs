using System.Collections.Generic;
using TestSwitchApi.DataModels;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Models.ApiModels;

namespace TestSwitchApi.Repositories
{
    public interface ICandidatesRepo
    {
        IEnumerable<CandidateDataModel> GetAllCandidates();
    }

    public class CandidatesRepo : ICandidatesRepo
    {
        private readonly TestSwitchDbContext _context;

        public CandidatesRepo(TestSwitchDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CandidateDataModel> GetAllCandidates()
        {
            return _context.Candidate;
        }
    }
}