namespace PerfumeTestApiBackend.Services
{
    public interface IEncriptionService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
