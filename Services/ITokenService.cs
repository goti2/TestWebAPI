using System.Collections.Generic;

namespace TestWebAPI.Services
{
    public interface ITokenService
    {
        string CreateToken(string username, string email, IEnumerable<string> roles);
    }
}