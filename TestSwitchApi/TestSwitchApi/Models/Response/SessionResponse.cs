namespace TestSwitchApi.Models.Response
{
    public class SessionResponse
    {
        private readonly string _sessionId;

        public SessionResponse(string session)
        {
            _sessionId = session;
        }

        public string SessionId => _sessionId;
    }
}