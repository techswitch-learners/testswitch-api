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
    [EnableCors("AllowOrigin")]
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
            var candidate = _candidates.GetCandidateByGuid(tokenId);
            if (candidate!=null)
            {
                var testSubmission = _submissions.AddTestSubmission(candidate.Id, newSubmission);
                return testSubmission;
            }

            return StatusCode(401, "Invalid token");
        }
    }
}