/*
 * Copyright (C) 2023 Patco, LLC - All Rights Reserved.
 * You may not use, distribute, make copy of, and modify this code without express written permission by Patco, LLC.
 */
using System;
using System.Collections;
using Common.Dispatcher;
using Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Waiter.Features.Home
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("Sample")]
    public class HomeController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        private string _test;
        private readonly string _test2;
        private readonly string _SampleApiTestKey;
        private readonly string _testKey;
        private readonly WaiterDbContext _context;

        public HomeController(IDispatcher dispatcher, IConfiguration config, WaiterDbContext context)
        {
            _dispatcher = dispatcher;
            _context = context;
            _testKey = config["ConnectionStrings:WaiterApiDatabase"];
            _SampleApiTestKey = config["SampleApi:ConnectionStrings:WaiterApiDatabase"];
            _test2 = config["ConnectionStrings:WaiterApiDatabase"];

            IDictionary environmentVariables = Environment.GetEnvironmentVariables();

            foreach (DictionaryEntry variable in environmentVariables)
            {
                string key = variable.Key.ToString();
                string value = variable.Value.ToString();
                _test2 += $"Key: {key}, Value: {value} /n";
            }
        }

        [HttpGet("GetVaueFromEnv")]
        public IActionResult Home2()
        {
            var z = _context.Database.CanConnect();
            return new JsonResult(_test2);
        }

        [HttpGet("_SampleApiTestKey")]
        public IActionResult SampleApiTestKey()
        {
            return new JsonResult(_SampleApiTestKey);
        }

        [HttpGet("_testKey")]
        public IActionResult TestKey()
        {
            return new JsonResult(_testKey);
        }
    }
}


