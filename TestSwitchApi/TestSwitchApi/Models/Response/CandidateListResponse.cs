using System.Collections.Generic;
using System.Linq;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;

namespace TestSwitchApi.Models.Response
{
    public class CandidateListResponse : ListResponse<CandidateResponse>
    {
        private CandidateListResponse(PageRequest pageRequest, IEnumerable<CandidateResponse> items, int totalNumberOfItems)
            : base(pageRequest, items, totalNumberOfItems, "candidates")
        {
        }

        public static CandidateListResponse Create(PageRequest pageRequest, IEnumerable<CandidateDataModel> candidates, int totalNumberOfItems)
        {
            var postModels = candidates.Select(candidate=>new CandidateResponse(candidate));
            return new CandidateListResponse(pageRequest, postModels, totalNumberOfItems);
        }
    }
}