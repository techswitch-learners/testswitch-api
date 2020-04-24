using System;
using System.Collections.Generic;
using System.Linq;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;

namespace TestSwitchApi.Repositories
{
    public class CandidateTestsRepo : ICandidateTestsRepo
    {
        private readonly TestSwitchDbContext _context;

        public CandidateTestsRepo(TestSwitchDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CandidateTestModel> GetSubmissionsByCandidateId(int id)
        {
            return _context.CandidateTests
                .Where(s => s.CandidateId == id)
                .OrderBy(s => s.TestId);
        }

        public CandidateTestModel AddTestSubmission(int candidateId,AddTestSubmissionRequestModel testSubmissionModel)
        {
            var insertTest = _context.CandidateTests.Add(new CandidateTestModel()
            {
                CandidateId = candidateId,
                TestId = testSubmissionModel.TestId,
                TestAnswer = testSubmissionModel.TestAnswer,
                EndTime = DateTime.Now,
            });
            _context.SaveChanges();
            return insertTest.Entity;
        }
    }
}