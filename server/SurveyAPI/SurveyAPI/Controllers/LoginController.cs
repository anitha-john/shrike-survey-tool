using AuthenticationBoundedContext;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SurveyAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/login")]
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
        [Route("AddUser")]
        [AllowAnonymous]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(500)]
        public async Task<IHttpActionResult> AddUser(User _user)
        {
            return Ok(await authenticate.AddUserAndRole(_user));
        }


        /// <summary>
        /// Get the JWT token for the credentials.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(500)]
        public IHttpActionResult Login([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isValid = false;
                   
                    
                    if (authenticate.IsUserValid(user)) // Service call to validate login with user and pass
                    {
                        isValid = true;
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
