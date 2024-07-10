using OutOfOffice.Server.Data.Responses.Interfaces;

namespace OutOfOffice.Server.Data.Responses
{
    public class MessageResponse : IResponse
    {
        public string Message { get; set; } = string.Empty;

        public MessageResponse(string message)
        {
            Message = message;
        }
    }
}
