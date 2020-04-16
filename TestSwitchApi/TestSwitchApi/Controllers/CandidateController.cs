using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestSwitchApi.DataModels;
using TestSwitchApi.Repositories;

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