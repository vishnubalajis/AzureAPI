using AzureAPI.Models;

namespace AzureAPI.Application.Services
{
    public interface ITokenService
    {
        string CreateToken(UserClaimsDto userClaims);
    }
}
