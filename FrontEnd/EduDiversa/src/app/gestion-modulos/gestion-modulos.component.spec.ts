import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionModulosComponent } from './gestion-modulos.component';

describe('GestionModulosComponent', () => {
  let component: GestionModulosComponent;
  let fixture: ComponentFixture<GestionModulosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GestionModulosComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GestionModulosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
