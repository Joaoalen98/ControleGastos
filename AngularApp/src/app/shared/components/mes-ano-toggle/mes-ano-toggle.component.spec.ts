import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MesAnoToggleComponent } from './mes-ano-toggle.component';

describe('MesAnoToggleComponent', () => {
  let component: MesAnoToggleComponent;
  let fixture: ComponentFixture<MesAnoToggleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MesAnoToggleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MesAnoToggleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
