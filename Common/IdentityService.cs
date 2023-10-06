using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Common;

public class IdentityService : IIdentityService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IdentityService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public UserInfo UserInfo()
    {
        var httpContextUser = _httpContextAccessor.HttpContext?.User;

        if (httpContextUser is null)
        {
            throw new ApplicationException("User not found");
        }
        return GetUserInfo(httpContextUser);
    }

    private UserInfo GetUserInfo(ClaimsPrincipal claimsPrincipal)
    {
        var claims = claimsPrincipal.Claims.ToDictionary(k => k.Type, v => v.Value);

        UserInfo userInfoDto = new UserInfo(claims["id"], claims["email"], bool.Parse(
                claims["email_verified"]), claims["username"]);

        return userInfoDto;
    }
}