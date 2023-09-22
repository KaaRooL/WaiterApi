/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using System.Security.Claims;

namespace Common;

public static class IdentityHelper
{
    public static UserInfo GetUserInfo(ClaimsPrincipal httpContextUser)
    {

        var claims = httpContextUser.Claims.ToDictionary(k => k.Type, v => v.Value);

        UserInfo userInfoDto = new UserInfo(claims["id"], claims["email"], bool.Parse(
                claims["email_verified"]), claims["username"]);

        return userInfoDto;
    }
}
