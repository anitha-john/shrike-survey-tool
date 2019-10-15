using Dapper.FluentMap.Mapping;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// The survey aggregate root 
    /// </summary>
    public class Survey
    {
        /// <summary>
        /// The survey ID which will be auto created as the survey is created.
        /// </summary>
        public int surveyId { get; set; }
        /// <summary>
        /// The heading of the survey.
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// The date on which the survey is created. Will be auto added.
        /// </summary>
        public DateTime createdOn { get; set; }
        [JsonIgnore]
        public string createdBy { get; set; }
        /// <summary>
        /// Indicates if the survey is live or not.
        /// </summary>
        public bool isPublished { get; set; }
    }

    public class SurveyMap : EntityMap<Survey>
    {
        public SurveyMap()
        {

            Map(i => i.surveyId).ToColumn("survey_id");
            Map(i => i.title).ToColumn("title");
            Map(i => i.createdOn).ToColumn("created_on");
            Map(i => i.createdBy).ToColumn("created_by");
            Map(i => i.isPublished).ToColumn("publish");

        }
    }

    /// <summary>
    /// The entity to view the survey
    /// </summary>
    public class SurveyQuestionaire
    {
        /// <summary>
        /// Associated survey ID
        /// </summary>
        public int surveyId { get; set; }
        /// <summary>
        /// Title of the survey.
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// Any error messages.
        /// </summary>
        public string error { get; set; }
        /// <summary>
        /// The questions for the survey.
        /// </summary>
        public IEnumerable<Questions> questions { get; set; }
    }
}

