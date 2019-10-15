using System;
using System.Collections.Generic;
using Dapper.FluentMap.Mapping;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Models
{

    public enum QuestionType
    {
        SingleLineInput,
        MultiLineInput,
        Dropdown,
        MultiSelect,
        Radio,
        FileUpload

    }

    public class QuestionsMap : EntityMap<Questions>
    {
        public QuestionsMap()
        {
            Map(i => i.questionId).ToColumn("question_id");
            Map(i => i.questionDesc).ToColumn("question_desc");
            Map(i => i.optionValuesJson).ToColumn("option_values");
            Map(i => i.questionTypeStringyfy).ToColumn("question_type");
            Map(i => i.optionValues).Ignore();
            Map(i => i.questionType).Ignore();
        }
    }

    /// <summary>
    /// The questions to be added in the survey
    /// </summary>
    public class Questions
    {
        /// <summary>
        /// Associated question Id, will be automatically populated once created.
        /// </summary>
        public int questionId { get; set; }
        /// <summary>
        /// The question to be created.
        /// </summary>
        public string questionDesc { get; set; }
        /// <summary>
        /// In case of multiple selections, the options to be created.
        /// </summary>
        public List<string> optionValues { get; set; }
        [JsonIgnore]
        public string optionValuesJson { get { return JsonConvert.SerializeObject(optionValues); } set { optionValues = JsonConvert.DeserializeObject<List<string>>(value); } }
        /// <summary>
        /// The type od control to be associated with the question.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public QuestionType questionType { get; set; }
        [JsonIgnore]
        public string questionTypeStringyfy { get { return questionType.ToString(); } set { questionType = (QuestionType)Enum.Parse(typeof(QuestionType), value); } }
    }

    /// <summary>
    /// The mapper entity between survey and questions
    /// </summary>
    public class SurveyQuestions
    {
        /// <summary>
        /// The survey question Id. Will be auto genrated when created.
        /// </summary>
        public int surveyQuestionId { get; set; }
        /// <summary>
        /// The associated survey ID
        /// </summary>
        public int surveyId { get; set; }
        /// <summary>
        /// The associated question ID
        /// </summary>
        public int questionId { get; set; }
        /// <summary>
        /// The order in which the questions has to be placed.
        /// </summary>
        public int order { get; set; }

    }
}
