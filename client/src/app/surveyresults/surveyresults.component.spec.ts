import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SurveyresultsComponent } from './surveyresults.component';

describe('SurveyresultsComponent', () => {
  let component: SurveyresultsComponent;
  let fixture: ComponentFixture<SurveyresultsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SurveyresultsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SurveyresultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
