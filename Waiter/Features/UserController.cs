/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Dispatcher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Waiter.Features;

[ApiController]
[Route("User")]
public class UserController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public UserController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
       
    }
    [HttpGet("UserInfo")]
    [Authorize]
    public async Task<IActionResult> UserInfo()
    {
        var user = IdentityHelper.GetUserInfo(HttpContext.User);
        return new JsonResult(user);
    }

   

    [HttpPost("CreateUser")]
    [Authorize]
    public async Task<IActionResult> CreateUser()
    {
        UserInfo userInfo = GetUserInfo();

        return new JsonResult(userInfo);
    }
    
    private UserInfo GetUserInfo()
    {
        var claims = HttpContext.User.Claims;
        var claimDictionary = claims.ToDictionary(k => k.Type, v => v.Value);

        UserInfo userInfo = new UserInfo(claimDictionary["id"], claimDictionary["email"], bool.Parse(
                claimDictionary["email_verified"]), claimDictionary["username"]);

        return userInfo;
    }
}
