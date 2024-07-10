using OutOfOffice.Server.Data.Responses.Interfaces;

namespace OutOfOffice.Server.Data.Responses
{
    public class ErrorResponse : IResponse
    {
        public string Error { get; set; } = string.Empty;

        public ErrorResponse(string error)
        {
            Error = error;
        }
    }
}
