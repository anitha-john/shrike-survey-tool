using AuthenticationBoundedContext;
using CreationSharingBoundedContext;
using Microsoft.Extensions.Caching.Memory;
using Models;
using SurveyAPI.Models;
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
    [RoutePrefix("api/v1/survey")]
    [JWTAuthorisation]
    public class SurveyController : BaseController
    {
        public ISurveyQuestions surveyQuestionRoot { get; set; }
        public ISurveyRoot surveyRoot { get; set; }
        public IMemoryCache memoryCache { get; set; }
        public IAuthenticate authenticationContext { get; set; }

        public SurveyController(ISurveyRoot _surveyRoot, ISurveyQuestions _surveyQuestionRoot, IMemoryCache _memoryCache, IAuthenticate authContext): base(_memoryCache, authContext)
        {
            surveyRoot = _surveyRoot;
            surveyQuestionRoot = _surveyQuestionRoot;
            authenticationContext = authContext;
            memoryCache = _memoryCache;
            
        }

        /// <summary>
        /// Get the survey for the given survey reference
        /// </summary>
        /// <param name="surveyId">The survey reference</param>
        /// <returns>Teh questionaire</returns>
        [HttpGet]
        
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(SurveyQuestionaire))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [Route("{surveyId}")]
        public async Task<IHttpActionResult> GetSurvey(int surveyId)
        {
            return Ok(await surveyRoot.ReadSurvey(surveyId));
        }

        /// <summary>
        /// Get all surveys
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(IEnumerable<Survey>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [Route("~/api/v1/surveys")]
        //[Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = "Bearer", Roles = SecurityRoles.ADMINISTRATOR, Policy = SecurityRoles.POLICY)]

        //[Authorize(Roles = SecurityRoles.ADMINISTRATOR)]
        public async Task<IHttpActionResult> Surveys(string emailId)
        {
            return Ok(await surveyRoot.GetSurveysForUser(emailId));
        }

        /// <summary>
        /// Publishes or hides the survey created
        /// </summary>
        /// <param name="surveyId">The survey ID to act upon</param>
        /// <param name="publish">Publish or hide</param>
        /// <returns>success or failure</returns>
        [HttpPut]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(bool))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [Route("publish/{surveyId}")]
        public async Task<IHttpActionResult> PublishOrHideSurvey(int surveyId, bool publish)
        {
            return Ok(await surveyRoot.PublishOrHideSurvey(surveyId, publish));
        }

        /// <summary>
        /// Add new survey.
        /// </summary>
        /// <param name="survey"></param>
        /// <returns>The ID of the new survey created</returns>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(int))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [Route("")]
        public async Task<IHttpActionResult> AddNewSurvey(Survey survey)
        {
            return Ok(await surveyRoot.AddSurvey(survey));
        }

        /// <summary>
        /// Adds the questions to the created survey
        /// </summary>
        /// <param name="questions">The list of questions</param>
        /// <param name="surveyId">The survey ID</param>
        /// <returns>True or false based on success or failure</returns>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, "", typeof(bool))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [Route("Questions")]
        public async Task<IHttpActionResult> Create(List<Questions> questions, int surveyId)
        {
            return Ok(await surveyQuestionRoot.AddSurveyQuestion(questions, surveyId));
        }

    }
}
