import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../shared/service/localstorageService';
import { SurveyService } from '../shared/service/survey-service';

@Component({
  selector: 'app-login',
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.scss']
})
export class LoginComponent implements OnInit {
  roles:string[]=['admin','user'];
  email:string;
  role:string;
  password:string;
  constructor(public loginService:SurveyService,public storage:LocalStorageService) { }

  ngOnInit() {
    
    
  }

  public Authenticate()
  {
    this.loginService.Authenticate({emailID:this.email,role:this.role,pwd:this.password}).subscribe(tokenInfo=>{
      this.storage.storeOnLocalStorage(tokenInfo.token);
    });
  }

}
