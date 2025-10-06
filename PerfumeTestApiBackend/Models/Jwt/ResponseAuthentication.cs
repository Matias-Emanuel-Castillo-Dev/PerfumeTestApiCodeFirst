namespace PerfumeTestApiBackend.Models.Jwt
{
    public class ResponseAuthentication
    {
        public string Token { get; set; }
        public DateTime Expire { get; set; }
    }
}
