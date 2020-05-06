namespace TestSwitchApi.Models.Request
{
    public class PageRequest
    {
            public int Page { get; set; } = 1;
            public int PageSize { get; set; } = 10;

            public string SessionId { get; }
    }
}