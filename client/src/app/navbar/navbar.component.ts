import { Component, OnInit } from '@angular/core';
import { SurveyService } from '../shared/service/survey-service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(public loginService:SurveyService) { }

  ngOnInit() {
  }

}
