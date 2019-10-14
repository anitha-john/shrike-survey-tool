export interface Question
{
    questionId:number;
    questionDesc:string;
    optionValues?:string[];
    optionValuesMulti?:Pair[];
    questionType:QuestionType;
    responseColl?:string[];
    reponse?:string;
}

export interface SurveyResponseModel
{
    surveyId:number;
    questionId:number;
    response:string;
    givenBy:string;
}
export interface Pair
{
    value:string;
    checked:boolean;
}

export enum QuestionType
{
    SingleLineInput,
    MultiLineInput,
    Dropdown,
    MultiSelect,
    Radio,
    FileUpload
}
