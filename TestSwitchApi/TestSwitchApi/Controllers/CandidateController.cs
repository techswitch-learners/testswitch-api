using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

        public CandidateController(ICandidatesRepo candidates, ICandidateTestsRepo submissions,ISessionService sessionService,IAdminRepo adminRepo)
        {
            _candidates = candidates;
            _submissions = submissions;
            _sessionService = sessionService;
            _adminRepo = adminRepo;
        }

        [HttpGet("")]
        public ActionResult<CandidateListResponse> GetCandidates([FromQuery] PageRequest pageRequest)
        {
            if(!HttpContext.Request.Cookies.ContainsKey("sessionId"))
            {
                return StatusCode(401, "Unauthorised");
            }
            else
            {
                var sessionId = HttpContext.Request.Cookies["sessionId"];
                var session = _adminRepo.GetSession(sessionId);
                if (session != null)
                {
                    if (_sessionService.IsValidSession(session.SessionEnd))
                    {
                        var candidates = _candidates.GetAllCandidates(pageRequest);
                        var candidateCount = _candidates.Count(pageRequest);
                        return new CandidateListResponse(pageRequest, candidates, candidateCount);
                    }
                }
            }

            return StatusCode(401, "Unauthorised");
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
    }
}