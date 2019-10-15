using AuthenticationBoundedContext;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SurveyAPI.Controllers
{
    public class LoginController : ApiController
    {
        public IAuthenticate authenticate { get; set; }

        private IMemoryCache memoryCache;
        private readonly TokenAuthOptions tokenOptions;

        public LoginController(IAuthenticate _authenticate, IMemoryCache _memoryCache, TokenAuthOptions _tokenOptions)
        {
            authenticate = _authenticate;
            memoryCache = _memoryCache;
            tokenOptions = _tokenOptions;           
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(500)]
        public IHttpActionResult Login([FromBody] dynamic user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isValid = false;
                    // 0 = Root Level -> no DB record
                    // 1 = Master Administrator -> DB Record present
                    // 2 = Customer Administrator -> DB Record present
                    // 3 = Environment Administrator (Future) -> DB Record present
                    // 4 = End-User (Future) -> DB Record present
                    // First check and do windows local administrator user authentication when doing partner login. These types are root level admins.
                    if (user.SecurityLevel == 0)
                    {
                        // Check with local admin user in the machine.
                        if (true) // Service call to validate login with user and pass
                        {
                            isValid = true;
                        }
                    }
                    else
                    {
                        //Non root users
                    }

                    if (isValid)
                    {
                        // Only when either of the user is validated, proceed to the token generation.
                        TokenService tokenService = new TokenService(memoryCache, tokenOptions);
                        var token = tokenService.GetJwtSecurityToken(user);

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        });
                    }
                    else
                        return Unauthorized();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            else
                return BadRequest(ModelState);
        }

    }
}
