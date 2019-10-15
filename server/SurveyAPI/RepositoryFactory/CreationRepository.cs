
using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace RepositoryFactory
{
    public class CreationRepository : ICreationRepository
    {
        //Add questions

        public async Task<int> AddQuestions(Questions _questions)
        {
            int questionId = 0;
            using (UnitOfWork _unitOfWork = UnitOfWork.GenerateUnitOfWork())
            {
                var sql = "insert into surveryengine.T_QUESTIONS_MASTER values (nextval('surveryengine.t_questions_master_question_id_seq'),@questionDesc, @questionType,@optionValuesJson) RETURNING question_id";
                var data = await _unitOfWork.Connection.QueryAsync(sql, _questions, transaction: _unitOfWork.Transaction);

                questionId = Convert.ToInt32(((IDictionary<string, object>)data.FirstOrDefault())["question_id"]);

                _unitOfWork.Commit();

            }
            return questionId;

        }

        public async Task<int> AddSurvey(Survey _survey)
        {
            int surveyId = 0;
            using (UnitOfWork _unitOfWork = UnitOfWork.GenerateUnitOfWork())
            {
                try
                {


                    var sql = "insert into surveryengine.t_survey values (nextval('surveryengine.t_survey_survey_id_seq'),@title, @createdOn,@createdBy,@isPublished) RETURNING survey_id";
                    var data = await _unitOfWork.Connection.QueryAsync(sql, _survey, transaction: _unitOfWork.Transaction);

                    surveyId = Convert.ToInt32(((IDictionary<string, object>)data.FirstOrDefault())["survey_id"]);

                    _unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollBack();
                }

            }
            return surveyId;
        }

        public async Task<bool> AddSurveyQuestions(List<Questions> questions, int surveyId)
        {
            using (UnitOfWork _unitOfWork = UnitOfWork.GenerateUnitOfWork())
            {
                try
                {
                    int order = 0;
                    List<SurveyQuestions> _surveyQuestions = new List<SurveyQuestions>();

                    foreach (var question in questions)
                    {
                        //insert into question master table
                        var query = "insert into surveryengine.T_QUESTIONS_MASTER values (nextval('surveryengine.t_questions_master_question_id_seq'),@questionDesc, @questionTypeStringyfy,CAST(@optionValuesJson as json)) RETURNING question_id";
                        var result = await _unitOfWork.Connection.QueryAsync(query, question, transaction: _unitOfWork.Transaction);


                        SurveyQuestions _surveyQuestion = new SurveyQuestions();
                        _surveyQuestion.questionId = Convert.ToInt32(((IDictionary<string, object>)result.FirstOrDefault())["question_id"]);
                        _surveyQuestion.surveyId = surveyId;
                        _surveyQuestion.order = ++order;

                        _surveyQuestions.Add(_surveyQuestion);

                    }

                    //inserting into the mapping table. Map between questions and survey
                    var sql = "insert into surveryengine.t_survey_questions values (nextval('surveryengine.t_survey_questions_survey_question_id_seq'),@surveyId, @questionId,@order) RETURNING survey_question_id";

                    var rows = await _unitOfWork.Connection.ExecuteAsync(sql, _surveyQuestions);


                    _unitOfWork.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    //log error
                    _unitOfWork.RollBack();
                    return false;
                }

            }

        }
    }
}

