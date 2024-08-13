namespace CS_RestApi.Domain
{
    public class AppResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "Success";

        public AppResponse(string message, bool success)
        {
            Message = message;
            Success = success;
        }

        public AppResponse(string message) 
        {
            Message = message;
        }

        
    }
}
