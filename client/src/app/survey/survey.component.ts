import { Component, OnInit } from '@angular/core';
import { SurveyQuestionaire } from '../shared/Models/SurveyQuestionaire';
import { Question, SurveyResponseModel, Pair } from '../shared/Models/question';
import { Router, ActivatedRoute } from '@angular/router';
import { SurveyService } from '../shared/service/survey-service';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.scss']
})
export class SurveyComponent implements OnInit {

 
  surveyResponseModel: SurveyResponseModel[]=[];
  surveyId: number;
  showSurveyForm: boolean;
  survey: SurveyQuestionaire;
  
  questionTypes:string[]=['SingleLineInput',
    'MultiLineInput',
    'Dropdown',
    'MultiSelect',
    'Radio',
    'FileUpload'];
    title:string;
  constructor( private router: Router,public surveyService:SurveyService,private route: ActivatedRoute)
  {
    
  }
  AddToResponse(question:Question,option:Pair)
  {
    option.checked=!option.checked;
    if(question.responseColl === undefined)
    {
      question.responseColl=[];
    }
    if(option.checked)
    {
      question.responseColl.push(option.value);
    }
    else
    {
      question.responseColl.splice(question.responseColl.indexOf(option.value),1);
    }
  }
 
  SaveSurvey()
  {
    this.surveyResponseModel=[];
    debugger;
    this.survey.questions.forEach((q:Question)=>{
      this.surveyResponseModel.push({questionId:q.questionId,surveyId:this.surveyId,response:q.responseColl && q.responseColl.length >0? q.responseColl.join(","):q.reponse,givenBy:'a.s@sc.com'})
    });

    this.surveyService.SaveSurvey(this.surveyResponseModel).subscribe(d=>{
      if(d){
        alert("Survey Posted.")
      }
      else
      {
        alert("Survey is already Complete.");
      }
    });

  }

 

  ngOnInit()
  {
    debugger;
    this.surveyId = this.route.snapshot.params['surveyId'];

   this.getSurvey()
  }

  getSurvey()
  {
    this.surveyService.GetSurvey(this.surveyId).subscribe((data:SurveyQuestionaire)=>{
      this.survey=data;
      this.survey.questions.forEach(a=>{
        debugger;
        if(a.questionType.toString() === "MultiSelect")  
        {
          a.optionValuesMulti=[];
          a.optionValues.forEach(option => {
            a.optionValuesMulti.push({value:option,checked:false});
          });
        }
      });
    });
  }



}
