using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace RepositoryFactory
{
    public class SurveyRepository : ISurveyRepository
    {
        public async Task<bool> PublishOrHideSurvey(int surveyId, bool publish)
        {
            using (UnitOfWork _unitOfWork = UnitOfWork.GenerateUnitOfWork())
            {
                try
                {
                    var sql = "update surveryengine.t_survey set publish=@publish where survey_id=@surveyid";
                    await _unitOfWork.Connection.ExecuteScalarAsync(sql, new { publish = publish, surveyid = surveyId }, transaction: _unitOfWork.Transaction);

                    _unitOfWork.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollBack();
                }
            }
            return false;
        }
        public async Task<SurveyQuestionaire> GetSurvey(int surveyId)
        {
            SurveyQuestionaire questionaire = new SurveyQuestionaire();

            using (UnitOfWork _unitOfWork = UnitOfWork.GenerateUnitOfWork())
            {
                try
                {



                    var survey = await _unitOfWork.Connection.QueryAsync<Survey>("select * from surveryengine.t_survey where survey_id=@surveyid", new { surveyid = surveyId },
                                                                                 transaction: _unitOfWork.Transaction);

                    if (survey.Count() > 0 && survey.FirstOrDefault().isPublished)
                    {
                        questionaire.title = survey.FirstOrDefault().title;
                        questionaire.surveyId = surveyId;

                        StringBuilder sbQuery = new StringBuilder();
                        sbQuery.Append("select q.*  from surveryengine.t_survey_questions sq ");
                        sbQuery.Append("inner join surveryengine.t_questions_master q on sq.question_id = q.question_id ");
                        sbQuery.Append("where sq.survey_id = @surveyid ");

                        var questions = await _unitOfWork.Connection.QueryAsync<Questions>(sbQuery.ToString(), new { surveyid = surveyId }, transaction: _unitOfWork.Transaction);

                        questionaire.questions = questions;
                    }
                    else
                    {
                        questionaire.error = "No such survey exists or the survey is expired";
                    }

                    _unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollBack();
                }

            }

            return questionaire;
        }

        public async Task<IEnumerable<Survey>> GetSurveysForUser(string emailId)
        {
            using (UnitOfWork _unitOfWork = UnitOfWork.GenerateUnitOfWork())
            {
                try
                {



                    return await _unitOfWork.Connection.QueryAsync<Survey>("select * from surveryengine.t_survey where created_by=@email", new { email = emailId },
                                                                                 transaction: _unitOfWork.Transaction);
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollBack();
                }
            }

            return new List<Survey>();
        }
    }
}
