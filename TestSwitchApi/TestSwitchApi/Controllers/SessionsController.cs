using System.Net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;
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
                try
                {
                    _submissions.AddTestSubmission(candidate.Id, newSubmission);
                    return StatusCode(200);
                }
                catch
                {
                    return StatusCode(500);
                }
            }

            return StatusCode(401, "Invalid token");
        }
    }
}