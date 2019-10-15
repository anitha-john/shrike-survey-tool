
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResponseBoundedContext
{
    public interface ISurveyResponse
    {
        Task<bool> AddSurveyResponse(IList<SurveyResponseModel> _surveyResponse);
        Task<IEnumerable<SurveyResponseModel>> GetSurveyResponse(int surveyid);
    }
}

