import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SurveycreationComponent } from './surveycreation/surveycreation.component';
import { SurveyComponent } from './survey/survey.component';
import { SurveyresultsComponent } from './surveyresults/surveyresults.component';


const routes: Routes = [
  {path: 'surveycreation', component: SurveycreationComponent},
  {path: 'survey/:surveyId', component: SurveyComponent},
  {path: 'surveyresults/:surveyId', component: SurveyresultsComponent},
  {path: '**', redirectTo: ''}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
