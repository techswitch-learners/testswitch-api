using System.Collections.Generic;
using System.Linq;
using TestSwitchApi.Models.DataModels;
using TestSwitchApi.Models.Request;

namespace TestSwitchApi.Models.Response
{
    public class CandidateListResponse
    {
        private readonly string _path;
        public IEnumerable<CandidateDataModel> Items { get; set; }
        public int TotalNumberOfItems { get; }
        public int Page { get; }
        public int PageSize { get; }

        public string NextPage
        {
            get
            {
                if (!HasNextPage())
                {
                    return null;
                }

                var url = $"/{_path}?page={Page + 1}&pageSize={PageSize}";

                return url;
            }
        }

        public string PreviousPage
        {
            get
            {
                if (Page <= 1)
                {
                    return null;
                }

                var url = $"/{_path}?page={Page - 1}&pageSize={PageSize}";

                return url;
            }
        }

        public CandidateListResponse(PageRequest pageRequest, IEnumerable<CandidateDataModel> candidates, int totalNumberOfItems)
        {
            Items = candidates;
            Page = pageRequest.Page;
            PageSize = pageRequest.PageSize;
            TotalNumberOfItems = totalNumberOfItems;
            _path = "candidates";
        }

        private bool HasNextPage()
        {
            return Page * PageSize < TotalNumberOfItems;
        }
    }
}