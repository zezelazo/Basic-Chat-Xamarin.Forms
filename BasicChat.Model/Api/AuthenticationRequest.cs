namespace BasicChat.Model.Api
{
    public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DeviceType { get; set; }
        public string DeviceId { get; set; }
    }
}