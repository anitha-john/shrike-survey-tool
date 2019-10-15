
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using RepositoryFactory;

namespace CreationSharingBoundedContext
{
    public class SurveyQuestionsAggregateRoot : ISurveyQuestions
    {
        public ICreationRepository repository { get; set; }
        public SurveyQuestionsAggregateRoot(ICreationRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> AddSurveyQuestion(List<Questions> _questions, int surveyId)
        {
            return await repository.AddSurveyQuestions(_questions, surveyId);

        }
    }
}

