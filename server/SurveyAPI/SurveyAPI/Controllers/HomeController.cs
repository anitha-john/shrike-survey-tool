using AuthenticationBoundedContext;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SurveyAPI.Controllers
{
    public class BaseController : ApiController
    {
        public IMemoryCache memoryCache { get; set; }
        public IAuthenticate authenticationContext { get; set; }


        public BaseController(IMemoryCache _memoryCache, IAuthenticate authContext)
        {
            memoryCache = _memoryCache;
            authenticationContext = authContext;


        }
    }
}
