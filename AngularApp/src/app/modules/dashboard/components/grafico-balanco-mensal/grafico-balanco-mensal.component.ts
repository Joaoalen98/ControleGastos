import { AfterViewInit, Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { Chart, registerables } from 'chart.js';

Chart.register(...registerables);

@Component({
  selector: 'app-grafico-balanco-mensal',
  templateUrl: './grafico-balanco-mensal.component.html',
  styleUrls: ['./grafico-balanco-mensal.component.scss']
})
export class GraficoBalancoMensalComponent implements AfterViewInit {
  @ViewChild('canvasBalanco') canvasBalanco!: ElementRef<HTMLCanvasElement>;
  @Input() valorReceita!: number;
  @Input() valorDespesa!: number;
  chartBalanco?: Chart;
  
  ngAfterViewInit(): void {
    console.log(this.valorDespesa);
    console.log(this.valorDespesa);
    this.chartBalanco?.destroy();
    this.graficoDespesaReceita(this.canvasBalanco.nativeElement);
  }

  graficoDespesaReceita(item: HTMLCanvasElement) {
    this.chartBalanco = new Chart(item, {
      type: 'bar',
      data: {
        labels: ['Receitas', 'Despesas'],
        datasets: [{
          label: 'Valor (R$)',
          data: [this.valorReceita, this.valorDespesa],
          borderWidth: 1,
          backgroundColor: [
            '#198754',
            '#dc3545'
          ]
        }]
      }
    });
  }
}
