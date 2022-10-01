using MovieRate.Core.Models;

namespace MovieRate.Core.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}