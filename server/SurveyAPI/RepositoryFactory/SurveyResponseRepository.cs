using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryFactory
{
    public class SurveyResponseRepository : ISurveyResponseRepository
    {

        public async Task<IEnumerable<SurveyResponseModel>> GetSurveyResponse(int surveyid)
        {
            IEnumerable<SurveyResponseModel> results = new List<SurveyResponseModel>();

            using (UnitOfWork _unitOfWork = UnitOfWork.GenerateUnitOfWork())
            {
                results = await _unitOfWork.Connection.QueryAsync<SurveyResponseModel>("select * from surveryengine.t_survey_results where survey_id=@surveyid", new { surveyid = surveyid });
            }

            return results;
        }

        public async Task<bool> SurveyResponse(IList<SurveyResponseModel> _surveyResponse)
        {
            using (UnitOfWork _unitOfWork = UnitOfWork.GenerateUnitOfWork())
            {
                try
                {
                    var count = await _unitOfWork.Connection.ExecuteScalarAsync<int>("select count(*) from surveryengine.t_survey_results where given_by_email=@email and survey_id=@surveyid", new { email = _surveyResponse.FirstOrDefault().givenBy, surveyid = _surveyResponse.FirstOrDefault().surveyId });

                    if (count <= 0)
                    {

                        var sql = "insert into surveryengine.t_survey_results values (nextval('surveryengine.t_survey_survey_id_seq'),@surveyId, @questionId,@response,@givenBy) RETURNING result_id";
                        var data = await _unitOfWork.Connection.ExecuteAsync(sql, _surveyResponse, transaction: _unitOfWork.Transaction);


                        _unitOfWork.Commit();
                        return true;
                    }

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollBack();
                    return false;
                }

            }
            return false;

        }
    }
}
