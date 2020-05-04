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
            var result = new CandidateTestModel();
            result = _context.CandidateTests
                .SingleOrDefault(s => s.CandidateId == candidateId && s.TestId == testSubmissionModel.TestId);

            if (result != null)
            {
                result.CandidateId = candidateId;
                result.TestId = testSubmissionModel.TestId;
                result.CandidateAnswer = testSubmissionModel.CandidateAnswer;
                result.EndTime = DateTime.Now;
            }

            _context.SaveChanges();
            return result;
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