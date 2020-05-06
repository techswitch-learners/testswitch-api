using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
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
        private readonly ISessionService _sessionService;
        private readonly IAdminRepo _adminRepo;

        public CandidateController(ICandidatesRepo candidates, ICandidateTestsRepo submissions,
            ISessionService sessionService, IAdminRepo adminRepo)
        {
            _candidates = candidates;
            _submissions = submissions;
            _sessionService = sessionService;
            _adminRepo = adminRepo;
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

        [HttpPost("create")]
        public ActionResult<CandidateDataModel> RegisterCandidate([FromForm] CandidateRequest candidateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCandidate = _candidates.Register(candidateRequest);
            return newCandidate;
        }

        [HttpGet("test-session")]
        public ActionResult<string> CheckSessionFromCookie()
        {
            var sessionIdValid = _sessionService.RequestHasValidSessionId(HttpContext, _adminRepo);
            if (!sessionIdValid)
            {
                return Unauthorized();
            }

            return "session valid.";
        }
    }
}