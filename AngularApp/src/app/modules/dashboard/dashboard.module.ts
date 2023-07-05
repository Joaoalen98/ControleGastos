import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { HomeComponent } from './components/home/home.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { GraficoBalancoMensalComponent } from './components/grafico-balanco-mensal/grafico-balanco-mensal.component';


@NgModule({
  declarations: [
    HomeComponent,
    GraficoBalancoMensalComponent,
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    SharedModule,
  ]
})
export class DashboardModule { }
