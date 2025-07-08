import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FamiliaDashboardComponent } from './familia-dashboard.component';

describe('FamiliaDashboardComponent', () => {
  let component: FamiliaDashboardComponent;
  let fixture: ComponentFixture<FamiliaDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FamiliaDashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FamiliaDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
