using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;
using TestSwitchApi.Models.Response;
using TestSwitchApi.Repositories;

namespace TestSwitchApi.Controllers
{
    [ApiController]
    [Route("/tests")]
    public class CandidateTestsController : Controller
    {
        private readonly ICandidatesRepo _candidates;
        private readonly ICandidateTestsRepo _candidateTests;

        public CandidateTestsController(ICandidatesRepo candidates, ICandidateTestsRepo candidateTests)
        {
            _candidates = candidates;
            _candidateTests = candidateTests;
        }

        [HttpGet("getStatus")]
        public ActionResult<CandidateTestStatusListResponse> GetCandidateTests([FromQuery] PageRequest pageRequest, string candidateGuid)
        {
            var candidate = _candidates.GetCandidateByGuid(candidateGuid);
            var tests = _candidateTests.GetSubmissionsByCandidateId(int.Parse(candidateGuid));
            var candidateTestModels = tests.ToList();
            var candidateTestsStatus = new List<CandidateTestStatus>();
            foreach (var test in candidateTestModels)
            {
                var candidateTestStatus = new CandidateTestStatus(test);
                candidateTestsStatus.Add(candidateTestStatus);
            }

            return new CandidateTestStatusListResponse(candidate, candidateTestsStatus);
        }
    }
}