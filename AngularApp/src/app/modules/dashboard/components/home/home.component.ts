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
  
  get receitas () { return this.movimentacoes?.filter(x => x.tipo === 'RECEITA'); }
  get valorReceita() {
    let valor = 0.00;
    for(const mov of this.receitas || []) {
      valor += mov.valor;
    }
    return valor;
  }

  get despesas() { return this.movimentacoes?.filter(x => x.tipo === 'DESPESA'); }
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
    this.mes = e.mes;
    this.ano = e.ano
    this.obterMovimentacoes(e.mes, e.ano);
  }

  obterMovimentacoes(mes: number, ano: number) {
    this.movimentacaoService.obter({ mes, ano })
      .subscribe({
      next: (value) => {
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
