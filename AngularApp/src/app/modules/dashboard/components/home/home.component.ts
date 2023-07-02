import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Chart, registerables } from 'chart.js';
import { Movimentacao } from 'src/app/interfaces/movimentacao.model';
import { MovimentacaoService } from 'src/app/services/api/movimentacao.service';
import { ToastService } from 'src/app/services/bootstrap/toast.service';

Chart.register(...registerables);

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  
  mes = new Date().getMonth();
  ano = new Date().getFullYear();
  movimentacoes?: Movimentacao[];
  chartBalanco?: Chart;
  
  get receitas () { return this.movimentacoes?.filter(x => x.tipo === 'Receita'); }
  get valorReceita() {
    let valor = 0.00;
    for(const mov of this.receitas || []) {
      valor += mov.valor;
    }
    return valor;
  }
  get despesas() { return this.movimentacoes?.filter(x => x.tipo === 'Despesa'); }
  get valorDespesa() {
    let valor = 0.00;
    for (const mov of this.despesas || []) {
      valor += mov.valor;
    }
    return valor;
  }

  @ViewChild('canvasBalanco') canvasBalanco!: ElementRef<HTMLCanvasElement>;

  constructor (
    private movimentacaoService: MovimentacaoService,
    private toastService: ToastService,
  ) { }

  ngOnInit(): void {
    this.obterMovimentacoes(this.mes, this.ano);
  }

  pesquisarMovimentacoes(e: any) {
    this.obterMovimentacoes(e.mes, e.ano);
  }

  obterMovimentacoes(mes: number, ano: number) {
    this.movimentacaoService.obter({ mes, ano })
      .subscribe({
      next: (value) => {
        console.log({value, param: { mes, ano } });
        this.movimentacoes = value;
        this.chartBalanco?.destroy();
        this.graficoDespesaReceita(this.canvasBalanco.nativeElement);
      },
      error: (res) => {
        this.toastService.show(JSON.stringify(res), { classname: 'bg-danger text-white' });
      }
    })
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
