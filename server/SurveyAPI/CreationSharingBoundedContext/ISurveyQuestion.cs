using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreationSharingBoundedContext
{
    public interface ISurveyQuestions
    {
        Task<bool> AddSurveyQuestion(List<Questions> _questions, int surveyId);
    }
}
