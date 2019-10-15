using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFactory
{
    public interface ICreationRepository
    {
        Task<bool> AddSurveyQuestions(List<Questions> questions, int surveyId);
        Task<int> AddSurvey(Survey _survey);
        Task<int> AddQuestions(Questions _questions);
    }
}
