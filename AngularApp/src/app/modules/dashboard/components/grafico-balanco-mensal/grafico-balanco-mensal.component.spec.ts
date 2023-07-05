import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GraficoBalancoMensalComponent } from './grafico-balanco-mensal.component';

describe('GraficoBalancoMensalComponent', () => {
  let component: GraficoBalancoMensalComponent;
  let fixture: ComponentFixture<GraficoBalancoMensalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GraficoBalancoMensalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GraficoBalancoMensalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
