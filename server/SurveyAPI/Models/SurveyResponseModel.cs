using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// The survey response aggregate root
    /// </summary>
    public class SurveyResponseModel
    {
        /// <summary>
        /// Auto created Id when the response is saved
        /// </summary>
        public int resultId { get; set; }
        /// <summary>
        /// Associated survey ID
        /// </summary>
        public int surveyId { get; set; }
        /// <summary>
        /// Associated question ID
        /// </summary>
        public int questionId { get; set; }
        /// <summary>
        /// The response captured for the question.
        /// </summary>
        public string response { get; set; }
        /// <summary>
        /// The user who gave the response.
        /// </summary>
        public string givenBy { get; set; }
    }


    public class SurveyResponseModelMap : EntityMap<SurveyResponseModel>
    {
        public SurveyResponseModelMap()
        {
            Map(i => i.resultId).ToColumn("result_id");
            Map(i => i.surveyId).ToColumn("survey_id");
            Map(i => i.questionId).ToColumn("question_id");
            Map(i => i.response).ToColumn("response");
            Map(i => i.givenBy).ToColumn("given_by_email");
        }
    }
}
