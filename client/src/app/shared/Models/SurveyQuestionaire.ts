import { Question } from './question';
export interface SurveyQuestionaire
{
    surveyId:number;
    title:string;
    error:string;
    questions:Question[];
}
