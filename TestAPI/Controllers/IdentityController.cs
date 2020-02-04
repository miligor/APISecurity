using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> RequestToken()
        {
            var discovery = await DiscoveryClient.GetAsync("http://localhost:5000");
            var tokenClient = new TokenClient(discovery.TokenEndpoint, "client1", "secret1");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("resource1");

            if (tokenResponse.IsError) { return new JsonResult(tokenResponse.Error); }
            else { return new JsonResult(tokenResponse.Json); }
        }

    }
}