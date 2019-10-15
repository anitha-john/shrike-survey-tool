﻿using Models;
using ResponseBoundedContext;
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
    [RoutePrefix("api/v1/surveyResponse")]
    public class SurveyResponseController : ApiController
    {
        public ISurveyResponse surveyResponseContext { get; set; }
        public SurveyResponseController(ISurveyResponse _surveyResponse)
        {
            surveyResponseContext = _surveyResponse;
        }

        /// <summary>
        /// Submits a survey with the response
        /// </summary>
        /// <param name="surveyResponse">The collection of responses for every question.</param>
        /// <returns>Success or failure</returns>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(bool))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [Route]
        public async Task<IHttpActionResult> Post(IList<SurveyResponseModel> surveyResponse)
        {
            return Ok(await surveyResponseContext.AddSurveyResponse(surveyResponse));
        }


    }
}

