import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionarAreasComponent } from './gestionar-areas.component';

describe('GestionarAreasComponent', () => {
  let component: GestionarAreasComponent;
  let fixture: ComponentFixture<GestionarAreasComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GestionarAreasComponent]
    });
    fixture = TestBed.createComponent(GestionarAreasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
