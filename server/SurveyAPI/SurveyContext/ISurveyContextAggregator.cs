using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyContext
{
    public interface ISurveyContextAggregator
    {
        Task<SurveyResult> SurveyResults(int surveyId);
    }
}
