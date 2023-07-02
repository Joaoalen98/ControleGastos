import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MesAnoToggleComponent } from './components/mes-ano-toggle/mes-ano-toggle.component';

@NgModule({
  declarations: [
    MesAnoToggleComponent,
  ],
  exports: [
    MesAnoToggleComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
