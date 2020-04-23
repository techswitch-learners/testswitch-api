using System.Collections.Generic;
using System.Linq;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;
using TestSwitchApi.Models.Response;

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

        public int Count(PageRequest pageRequest)
        {
            return _context.Candidates
                .Count();
        }

        public CandidateDataModel Register(CandidateRequest candidateRequest)
        {
            var response = _context.Candidates.Add(new CandidateDataModel()
            {
                FirstName = candidateRequest.FirstName,
                LastName = candidateRequest.LastName,
                Email = candidateRequest.Email,
            });
            //TODO: Can generate unique Url here and add to DB when we need to.
            _context.SaveChanges();
            return response.Entity;
        }
    }
}