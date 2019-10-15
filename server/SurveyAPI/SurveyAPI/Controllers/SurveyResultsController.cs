using AuthenticationBoundedContext;
using Microsoft.Extensions.Caching.Memory;
using Models;
using SurveyAPI.Models;
using SurveyContext;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SurveyAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/surveyResults")]
    [JWTAuthorisation]
    public class SurveyResultsController : BaseController
    {
        public ISurveyContextAggregator surveyContext { get; set; }
        public IMemoryCache memoryCache { get; set; }

        public SurveyResultsController(ISurveyContextAggregator _surveyContext, IMemoryCache _memoryCache, IAuthenticate authContext) : base(_memoryCache, authContext)
        {
            surveyContext = _surveyContext;
            memoryCache = _memoryCache;

        }

        /// <summary>
        /// Gets the result of a particular survey
        /// </summary>
        /// <param name="surveyId">The survey ID</param>
        /// <returns>survey results</returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(SurveyResult))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [Route("{surveyId}")]
        public async Task<IHttpActionResult> Get(int surveyId)
        {
            return Ok(await surveyContext.SurveyResults(surveyId));
        }
    }
}

