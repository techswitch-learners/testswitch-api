using Microsoft.AspNetCore.Mvc;
using TestSwitchApi.Models.Request;
using TestSwitchApi.Models.Response;
using TestSwitchApi.Repositories;

namespace TestSwitchApi.Controllers
{
    [ApiController]
    [Route("/submissions")]
    public class TestSubmissionController : Controller
    {
        private readonly ICandidateTestsRepo _submissions;
        private readonly ICandidatesRepo _candidates;

        public TestSubmissionController(ICandidateTestsRepo submissions, ICandidatesRepo candidates)
        {
            _submissions = submissions;
            _candidates = candidates;
        }

        [HttpGet]
        public ActionResult<CandidateTestResponseModel> SubmissionsByCandidate(int candidateId)
        {
            var candidate = _candidates.GetCandidateById(candidateId);
            var submissions = _submissions.GetSubmissionsById(candidateId);

            return new CandidateTestResponseModel(submissions, candidate);
        }
    }
}