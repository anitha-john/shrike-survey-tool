using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreationSharingBoundedContext
{
    public interface ISurveyRoot
    {
        Task<int> AddSurvey(Survey _survey);
        Task<bool> PublishOrHideSurvey(int surveyId, bool publish);
        Task<SurveyQuestionaire> ReadSurvey(int surveyId);
        Task<IEnumerable<Survey>> GetSurveysForUser(string emailId);
    }
}
