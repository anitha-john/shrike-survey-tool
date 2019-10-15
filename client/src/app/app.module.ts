import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SurveyComponent } from './survey/survey.component';
import { SurveycreationComponent } from './surveycreation/surveycreation.component';
import { SurveyresultsComponent } from './surveyresults/surveyresults.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { AgGridModule } from 'ag-grid-angular';
import { ServiceBase } from './shared/service/service-base';
import { SurveyService } from './shared/service/survey-service';
import { HttpClientModule } from '@angular/common/http';
import {  LoginComponent } from './login-component/login-component.component'; 
import { StorageServiceModule } from "ngx-webstorage-service";
import { LocalStorageService } from './shared/service/localstorageService';


@NgModule({
  declarations: [
    AppComponent,
    SurveyComponent,
    SurveycreationComponent,
    SurveyresultsComponent,
    NavbarComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    AgGridModule.withComponents([]),
    HttpClientModule,
    StorageServiceModule 
  ],
  providers: [
    ServiceBase,
    SurveyService,
    LocalStorageService,
    
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
