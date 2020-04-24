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
        private readonly ICandidateTestsRepo _submissions;

        public CandidateController(ICandidatesRepo candidates, ICandidateTestsRepo submissions)
        {
            _candidates = candidates;
            _submissions = submissions;
        }

        [HttpGet("")]
        public ActionResult<CandidateListResponse> GetCandidates([FromQuery] PageRequest pageRequest)
        {
            var candidates = _candidates.GetAllCandidates(pageRequest);
            var candidateCount = _candidates.Count(pageRequest);
            return new CandidateListResponse(pageRequest, candidates, candidateCount);
        }

        [HttpGet("{candidateId}")]
        public ActionResult<CandidateTestResponseModel> GetCandidateTestSubmissions(int candidateId)
        {
            var candidate = _candidates.GetCandidateById(candidateId);
            var submissions = _submissions.GetSubmissionsByCandidateId(candidateId);
            return new CandidateTestResponseModel(submissions, candidate);
        }
    }
}