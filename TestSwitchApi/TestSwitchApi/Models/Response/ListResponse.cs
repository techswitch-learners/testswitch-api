using System.Collections.Generic;
using TestSwitchApi.Models.Request;

namespace TestSwitchApi.Models.Response
{
    public class ListResponse<T>
    {
        private readonly string _path;
        public IEnumerable<T> Items { get; }
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

        public ListResponse(PageRequest page, IEnumerable<T> items, int totalNumberOfItems, string path)
        {
            Items = items;
            TotalNumberOfItems = totalNumberOfItems;
            Page = page.Page;
            PageSize = page.PageSize;
            _path = path;
        }

        private bool HasNextPage()
        {
            return Page * PageSize < TotalNumberOfItems;
        }
    }
}