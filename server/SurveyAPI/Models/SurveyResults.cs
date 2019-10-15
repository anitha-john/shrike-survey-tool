using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// Entity for the survey responses
    /// </summary>
    public class SurveyResults
    {
        /// <summary>
        /// The question
        /// </summary>
        public string questionDesc { get; set; }
        /// <summary>
        /// The response for the question.
        /// </summary>
        public string questionResponse { get; set; }
        /// <summary>
        /// The user who provided the response.
        /// </summary>
        public string givenBy { get; set; }
    }

    /// <summary>
    /// The survey result entity
    /// </summary>
    public class SurveyResult
    {
        /// <summary>
        /// Survey results
        /// </summary>
        public IList<SurveyResults> surveyResults { get; set; }
        /// <summary>
        /// The name of the survey
        /// </summary>
        public string title { get; set; }
    }
}
