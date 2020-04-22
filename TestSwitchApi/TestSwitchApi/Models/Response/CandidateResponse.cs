using TestSwitchApi.Models.DataModels;

namespace TestSwitchApi.Models.Response
{
    public class CandidateResponse
    {
        private readonly CandidateDataModel _candidate;

        public CandidateResponse(CandidateDataModel candidateDataModel)
        {
            _candidate = candidateDataModel;
        }

        public int Id => _candidate.Id;
        public string FirstName => _candidate.FirstName;
        public string LastName => _candidate.LastName;
        public string Email => _candidate.Email;
    }
}