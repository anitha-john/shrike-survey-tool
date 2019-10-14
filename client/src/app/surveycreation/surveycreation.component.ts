import { Component, OnInit } from '@angular/core';
import { Survey } from '../shared/Models/survey';
import { Question, QuestionType } from '../shared/Models/question';
import { Router } from '@angular/router';
import { SurveyService } from '../shared/service/survey-service';

@Component({
  selector: 'app-surveycreation',
  templateUrl: './surveycreation.component.html',
  styleUrls: ['./surveycreation.component.scss']
})
export class SurveycreationComponent implements OnInit {

 
 
  
  showSurveyForm: boolean;
  surveys: Survey[];
  questions: Question[]=[];
  questionTypes:string[]=['SingleLineInput',
    'MultiLineInput',
    'Dropdown',
    'MultiSelect',
    'Radio',
    'FileUpload'];
    title:string;
  constructor(private router: Router,public surveyService:SurveyService)
  {
    
  }
 
  SaveSurvey()
  {
     var newSurvey:Survey={title:this.title,isPublished:false};

      this.surveyService.AddSurvey(newSurvey).subscribe((s:number)=>{
        this.surveyService.AddQyestions(this.questions,s).subscribe(d=>{
          alert("Survey Created.");

          this.showSurveyForm=false;
          this.getSurveysForUser();
        });
      });

  }

  AddOptions(optionText:string,question:Question)
  {
    question.optionValues.push(optionText);
    optionText='';
  }
  AddQuestions()
  {
    var newQuestion:Question={questionId:0,questionDesc:'',questionType:QuestionType.SingleLineInput,optionValues:[]}
    this.questions.push(newQuestion);
  }

  ngOnInit()
  {
   this.getSurveysForUser();
  }

  getSurveysForUser()
  {
    this.surveyService.GetSurveyForUser(encodeURIComponent('a.s@sc.com') ).subscribe((data:Survey[])=>{
      this.surveys=data;
    });
  }

  Navigate(surveyId:number, location:string)
  {
    this.router.navigate([location,surveyId])
  }

  publishSurvey(surveyid:number,isPublish:boolean)
  {
    this.surveyService.PublishSurvey(surveyid,isPublish).subscribe(s=>{
      alert(isPublish?"Published.": "Un-Published.")
    },e=>{alert("Failed.")});
  }

}
