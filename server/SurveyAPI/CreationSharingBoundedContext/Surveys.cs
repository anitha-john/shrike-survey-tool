
using Models;
using RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreationSharingBoundedContext
{
    public class SurveyRoot : ISurveyRoot
    {
        public ICreationRepository repository { get; set; }
        public ISurveyRepository surveyRepository { get; set; }

        public SurveyRoot(ICreationRepository _repository, ISurveyRepository _surveyRepository)
        {
            repository = _repository;
            surveyRepository = _surveyRepository;
        }
        public async Task<int> AddSurvey(Survey _survey)
        {
            _survey.createdOn = DateTime.Now;
            _survey.createdBy = "default.user@test.com";

            return await repository.AddSurvey(_survey);

        }

        public async Task<SurveyQuestionaire> ReadSurvey(int surveyId)
        {
            return await surveyRepository.GetSurvey(surveyId);
        }
        public async Task<bool> PublishOrHideSurvey(int surveyId, bool publish)
        {
            return await surveyRepository.PublishOrHideSurvey(surveyId, publish);

        }

        public async Task<IEnumerable<Survey>> GetSurveysForUser(string emailId)
        {
            return await surveyRepository.GetSurveysForUser(emailId);
        }
    }
}

