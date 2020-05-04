using System.Net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;
using TestSwitchApi.Models.Response;
using TestSwitchApi.Repositories;

namespace TestSwitchApi.Controllers
{
  [ApiController]
  [Route("/sessions")]
  public class SessionsController : Controller
    {
        private readonly ICandidatesRepo _candidates;
        private readonly ICandidateTestsRepo _submissions;

        public SessionsController(ICandidatesRepo candidates, ICandidateTestsRepo submissions)
        {
            _candidates = candidates;
            _submissions = submissions;
        }

        [HttpGet("{tokenId}")]
        public ActionResult<CandidateTestStatusResponseModel> GetCandidateTestStatus(string tokenId)
        {
            var candidate = _candidates.GetCandidateByGuid(tokenId);
            if (candidate!=null)
            {
                var submissions = _submissions.GetSubmissionsByCandidateId(candidate.Id);
                return new CandidateTestStatusResponseModel(submissions, candidate);
            }

            return StatusCode(401, "Invalid token");
        }

        [HttpPost("{tokenId}")]
        public ActionResult<CandidateTestModel> AddTestSubmission([FromRoute] string tokenId, [FromBody] AddTestSubmissionRequestModel newSubmission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidate = _candidates.GetCandidateByGuid(tokenId);

            if (candidate!=null)
            {
                return _submissions.AddTestSubmission(candidate.Id, newSubmission);
            }

            return StatusCode(401, "Invalid token");
        }
    }
}