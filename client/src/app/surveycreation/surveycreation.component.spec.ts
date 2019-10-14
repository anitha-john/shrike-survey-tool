import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SurveycreationComponent } from './surveycreation.component';

describe('SurveycreationComponent', () => {
  let component: SurveycreationComponent;
  let fixture: ComponentFixture<SurveycreationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SurveycreationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SurveycreationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
