import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SolicitudesGestionarComponent } from './solicitudes-gestionar.component';

describe('SolicitudesGestionarComponent', () => {
  let component: SolicitudesGestionarComponent;
  let fixture: ComponentFixture<SolicitudesGestionarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SolicitudesGestionarComponent]
    });
    fixture = TestBed.createComponent(SolicitudesGestionarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
