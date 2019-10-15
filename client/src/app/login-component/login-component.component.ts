import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from '../shared/service/localstorageService';
import { SurveyService } from '../shared/service/survey-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.scss']
})
export class LoginComponent implements OnInit {
  roles=[{name:'admin',value:0},{name:'user',value:0}];
  email:string;
  role:any;
  password:string;
  constructor(private router: Router,public loginService:SurveyService,public storage:LocalStorageService) { }

  ngOnInit() {
    
    
  }

  public Authenticate()
  {
    
    this.loginService.Authenticate({emailID:this.email,role:this.role.value,pwd:this.password}).subscribe(tokenInfo=>{
      this.storage.storeOnLocalStorage(tokenInfo.token);
      this.router.navigate(['/surveycreation']);
      this.loginService.Role=this.role.value;

    },error=>alert("login failed!!"));
  }

}
