import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { inherits } from "util";
import { ServiceBase } from "./service-base";
import { Survey } from '../models/survey';
import { Observable } from "rxjs";
import { Question, SurveyResponseModel } from '../models/question';
import { SurveyQuestionaire } from "../models/SurveyQuestionaire";

@Injectable()
export class SurveyService extends ServiceBase {
   
   
  GetSurveyResults(surveyId: number): Observable<any[]> {
    var query=`surveyResults/${surveyId}`;
    return this.get(query);
  }
  SaveSurvey(surveyResponseModel: SurveyResponseModel[]): Observable<boolean> {
    var query=`surveyResponse`;
    return this.post(surveyResponseModel,query);
  }
  GetSurvey(surveyId: number): Observable<SurveyQuestionaire> {
    var query=`survey/${surveyId}`;
    return this.get(query);
  }
  PublishSurvey(surveyId: any,isPublish:boolean): any {
    var query=`survey/publish/${surveyId}?publish=${isPublish}`;
    return this.put(null,query);
  }
  public GetSurveyForUser(emailId:string):Observable<Survey[]>
  {
      var query=`surveys?emailId=${emailId}`;
      return this.get(query);
  }

  public AddSurvey(survey:Survey):Observable<number>
  {
    var query=`survey`;
      return this.post(survey,query);
  }

  public AddQyestions(questions:Question[],surveyId:number):Observable<boolean>
  {
    var query=`survey/Questions?surveyId=${surveyId}`;
      return this.post(questions,query);
  }
    
}
