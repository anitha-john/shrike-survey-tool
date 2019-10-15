import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SurveycreationComponent } from './surveycreation/surveycreation.component';
import { SurveyComponent } from './survey/survey.component';
import { SurveyresultsComponent } from './surveyresults/surveyresults.component';
import { LoginComponent } from './login-component/login-component.component';


const routes: Routes = [
  {path: 'surveycreation', component: SurveycreationComponent},
  {path: 'survey/:surveyId', component: SurveyComponent},
  {path: 'surveyresults/:surveyId', component: SurveyresultsComponent},
  {path: 'login', component: LoginComponent},
  {path: '**', redirectTo: 'login'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
