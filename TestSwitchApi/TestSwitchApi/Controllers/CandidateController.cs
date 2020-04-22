using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;
using TestSwitchApi.Models.Response;
using TestSwitchApi.Repositories;
using TestSwitchApi.Services;

namespace TestSwitchApi.Controllers
{
    [ApiController]
    [Route("/candidates")]
    public class CandidateController : Controller
    {
        private readonly ICandidatesRepo _candidates;

        public CandidateController(ICandidatesRepo candidates)
        {
            _candidates = candidates;
        }

        [HttpGet("")]
        public ActionResult<CandidateListResponse> GetCandidates([FromQuery] PageRequest pageRequest)
        {
            var candidates = _candidates.GetAllCandidates(pageRequest);
            var candidateCount = _candidates.Count(pageRequest);
            return CandidateListResponse.Create(pageRequest, candidates, candidateCount);
        }

        [HttpPost("register")]
        public ActionResult<CandidateRegisteredResponse> RegisterCandidate([FromForm] CandidateRequest candidateRequest)
        {
            response = _candidates.Register(candidateRequest);
            return response;
        }
    }
}