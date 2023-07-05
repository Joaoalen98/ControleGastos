import { Component, OnInit, ViewChild, ElementRef, OnChanges, SimpleChanges } from '@angular/core';
import { Movimentacao } from 'src/app/interfaces/movimentacao.model';
import { MovimentacaoService } from 'src/app/services/api/movimentacao.service';
import { ToastService } from 'src/app/services/bootstrap/toast.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  carregando = false;
  mes = new Date().getMonth() + 1;
  ano = new Date().getFullYear();
  movimentacoes?: Movimentacao[];

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
    this.carregando = true;
    this.movimentacaoService.obter({ mes, ano })
      .subscribe({
      next: (value) => {
        this.movimentacoes = value;
        this.carregando = false;
      },
      error: (res) => {
        this.toastService.show(JSON.stringify(res), { classname: 'bg-danger text-white' });
      }
    })
  }

  obterReceita() {
    let valor = 0.00;
    for (const mov of this.movimentacoes?.filter(x => x.tipo === 'RECEITA') || []) {
      valor += mov.valor;
    }
    return valor;
  }

  obterDespesa() {
    let valor = 0.00;
    for (const mov of this.movimentacoes?.filter(x => x.tipo === 'DESPESA') || []) {
      valor += mov.valor;
    }
    return valor;
  }
}
