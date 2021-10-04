using ASPNetCoreMastersTodoList.API.BindingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMastersTodoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AuthenticationSettings _settings;
        private readonly IHostEnvironment _hostEnvironment;
        public UsersController(IOptions<AuthenticationSettings> options, IHostEnvironment hostEnvironment)
        {
            this._settings = options.Value;
            this._hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var key = this._settings.jwt.SecurityKey;
            var issuer = this._settings.jwt.Issuer;
            var audience = this._settings.jwt.Audience;
            return Ok("Security Key: " + key +", Issuer: " + issuer + ", Audience: "+audience );
        }
    }
}
