using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFactory
{
    public interface ISurveyResponseRepository
    {
        Task<bool> SurveyResponse(IList<SurveyResponseModel> _surveyResponse);
        Task<IEnumerable<SurveyResponseModel>> GetSurveyResponse(int surveyid);
    }
}
