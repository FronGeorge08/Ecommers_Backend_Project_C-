namespace EccomersAPI.DataAbstraction.Security
{
    public interface IHashingService
    {
        string HashPassword(string password, string salt);
        string GenerateSalt();
        bool VerifyPassword(string originalPassword,string passwordHashed, string salt);

    }
}
