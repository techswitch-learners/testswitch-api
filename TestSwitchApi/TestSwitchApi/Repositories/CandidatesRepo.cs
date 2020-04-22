using System.Collections.Generic;
using System.Linq;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;

namespace TestSwitchApi.Repositories
{
    public class CandidatesRepo : ICandidatesRepo
    {
        private readonly TestSwitchDbContext _context;

        public CandidatesRepo(TestSwitchDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CandidateDataModel> GetAllCandidates(PageRequest pageRequest)
        {
            return _context.Candidates
                .OrderBy(c => c.FirstName)
                .Skip((pageRequest.Page - 1) * pageRequest.PageSize)
                .Take(pageRequest.PageSize);
        }
        
        public CandidateDataModel GetCandidateById(int id)
        {
            return _context.Candidates
                .Single(c => c.Id == id);

        }

        public int Count(PageRequest pageRequest)
        {
            return _context.Candidates
                .Count();
        }
    }
}