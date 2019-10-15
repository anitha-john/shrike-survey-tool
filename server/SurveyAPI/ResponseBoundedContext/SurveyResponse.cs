using Models;
using System;
using System.Threading.Tasks;
using RepositoryFactory;
using System.Collections.Generic;

namespace ResponseBoundedContext
{
    public class SurveyResponse : ISurveyResponse
    {
        public ISurveyResponseRepository surveyResponseRepository { get; set; }
        public SurveyResponse(ISurveyResponseRepository _surveyResponseRepository)
        {
            surveyResponseRepository = _surveyResponseRepository;
        }

        public async Task<bool> AddSurveyResponse(IList<SurveyResponseModel> _surveyResponse)
        {
            //check the question id and survey id from creation bounded context
            return await surveyResponseRepository.SurveyResponse(_surveyResponse);
        }


        public async Task<IEnumerable<SurveyResponseModel>> GetSurveyResponse(int surveyid)
        {
            return await surveyResponseRepository.GetSurveyResponse(surveyid);
        }

    }
}

