namespace BasicChat.Service
{
    public class SimpleServiceResponse<T>
    {
        public SimpleServiceResponse(EResponseType responseType, T data, string errorMessage = "")
        {
            Data = data;
            ResponseType = responseType;
            ErrorMessage = errorMessage;
        }

        public T Data { get; }
        public string ErrorMessage { get; }
        public EResponseType ResponseType { get; }
    }
}