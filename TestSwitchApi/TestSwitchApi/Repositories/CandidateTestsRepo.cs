using System;
using System.Collections.Generic;
using System.Linq;
using TestSwitchApi.Models.ApiModels;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;
using TestSwitchApi.Models.Response;

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

        public CandidateTestModel AddTestSubmission(int candidateId, AddTestSubmissionRequestModel testSubmissionModel)
        {
            var result = _context.CandidateTests
                .SingleOrDefault(s => s.CandidateId == candidateId && s.TestId == testSubmissionModel.TestId);

            if (result != null)
            {
                CandidateId = candidateId,
                TestId = testSubmissionModel.TestId,
                CandidateAnswer = testSubmissionModel.CandidateAnswer,
                EndTime = DateTime.Now,
            });
            _context.SaveChanges();
            return insertTest.Entity;
        }

        public CandidateTestStatus GetCandidateTestStatus(int candidateId, string testName)
        {
            var test = _context.CandidateTests
                .Where(s => s.Title == testName);
            var testModel = new CandidateTestModel();
            foreach (var t in test)
            {
                testModel = t;
            }

            return new CandidateTestStatus(testModel);
        }
    }
}