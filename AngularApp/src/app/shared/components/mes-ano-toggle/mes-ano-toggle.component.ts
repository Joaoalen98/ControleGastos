import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-mes-ano-toggle',
  templateUrl: './mes-ano-toggle.component.html',
  styleUrls: ['./mes-ano-toggle.component.scss']
})
export class MesAnoToggleComponent {
  mes: number = new Date().getMonth() + 1;
  ano: number = new Date().getFullYear();
  @Output() mesAnoChange = new EventEmitter<{ mes: number, ano: number }>();

  constructor() { }

  enviaEvento(val: number) {
    this.mes += val;
    
    if (this.mes === 13) {
      this.mes = 1;
      this.ano += 1;
    } else if (this.mes === 0) {
      this.mes = 12;
      this.ano -= 1;
    }

    this.mesAnoChange.emit({ mes: this.mes, ano: this.ano });
  }
}
