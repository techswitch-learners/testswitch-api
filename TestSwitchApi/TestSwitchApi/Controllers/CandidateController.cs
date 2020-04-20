using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using TestSwitchApi.Models.DataModels;
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
        public IEnumerable<CandidateDataModel> GetCandidates()
        {
            var candidates = _candidates.GetAllCandidates();
            return candidates;
        }
    }
}