
using CreationSharingBoundedContext;
using Models;
using ResponseBoundedContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SurveyContext
{
    public class SurveyContextAggregator : ISurveyContextAggregator
    {
        public ISurveyResponse surveyResponseBoundedContext { get; set; }
        public ISurveyRoot surveyRootBoundedContext { get; set; }
        public SurveyContextAggregator(ISurveyResponse _surveyResponseBoundedContext, ISurveyRoot surveyRoot)
        {
            surveyResponseBoundedContext = _surveyResponseBoundedContext;
            surveyRootBoundedContext = surveyRoot;
        }

        public async Task<SurveyResult> SurveyResults(int surveyId)
        {
            var response = await surveyResponseBoundedContext.GetSurveyResponse(surveyId);
            var survey = await surveyRootBoundedContext.ReadSurvey(surveyId);
            SurveyResult surveyResult = new SurveyResult();
            surveyResult.title = survey.title;

            IList<SurveyResults> results = new List<SurveyResults>();

            foreach (var data in response)
            {
                SurveyResults result = new SurveyResults();
                result.questionDesc = survey.questions.Where(q => q.questionId == data.questionId).Select(q => q.questionDesc).FirstOrDefault();
                result.questionResponse = data.response;
                result.givenBy = data.givenBy;

                results.Add(result);
            }

            surveyResult.surveyResults = results;

            return surveyResult;
        }
    }
}

