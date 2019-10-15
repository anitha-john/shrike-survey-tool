using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFactory
{
    public interface ISurveyRepository
    {
        Task<SurveyQuestionaire> GetSurvey(int surveyId);
        Task<bool> PublishOrHideSurvey(int surveyId, bool publish);
        Task<IEnumerable<Survey>> GetSurveysForUser(string emailId);
    }
}
