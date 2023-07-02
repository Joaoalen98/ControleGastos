import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Movimentacao } from 'src/app/interfaces/movimentacao.model';
import { MovimentacaoService } from 'src/app/services/api/movimentacao.service';
import { ToastService } from 'src/app/services/bootstrap/toast.service';
import { ModalMovimentacaoComponent } from '../modal-movimentacao/modal-movimentacao.component';
import { CategoriasModel } from 'src/app/services/api/interfaces/categorias.model';

@Component({
  selector: 'app-receitas',
  templateUrl: './receitas.component.html',
  styleUrls: ['./receitas.component.scss']
})
export class ReceitasComponent implements OnInit {
  mes: number = new Date().getMonth();
  ano: number = new Date().getFullYear();
  tipoMovimentacao = 'RECEITA';
  movimentacoes?: Movimentacao[];
  categorias!: CategoriasModel;
  

  constructor(
    private movimentacaoService: MovimentacaoService,
    private toastService: ToastService,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.obterMovimentacoes(
      this.mes,
      this.ano
    );
    this.obterCategorias();
  }

  pesquisaMovimentacoes(e: any) {
    this.mes = e.mes;
    this.ano = e.ano;
    this.obterMovimentacoes(e.mes, e.ano);
  }

  obterMovimentacoes(mes: number, ano: number) {
    this.movimentacaoService.obter({
      mes,
      ano,
      tipoMovimentacao: this.tipoMovimentacao
    })
    .subscribe({
      next: (val) => {
        this.movimentacoes = val;
      },
      error: (val) => {
        this.toastService.show('Ocorreu um erro ao obter as movimentações', { classname: 'bg-danger text-white' });
      }
    });
  }

  calculaValores() {
    let pendentes = 0.00;
    let recebidos = 0.00;
    let total = 0.00;
  }

  obterCategorias() {
    this.movimentacaoService.obterCategorias()
      .subscribe({
        next: (res) => {
          this.categorias = res;
        },
        error: (res) => {

        }
      });
  }

  abrirModal(movimentacao?: Movimentacao) {
    const modalRef = this.modalService.open(ModalMovimentacaoComponent);
    modalRef.componentInstance.tipo = 'RECEITA';
    modalRef.componentInstance.categorias = this.categorias.receita;
    modalRef.componentInstance.movimentacao = movimentacao;

    modalRef.componentInstance.adicionadoEvent.subscribe(() => {
      this.obterMovimentacoes(this.mes, this.ano);
    });
  }
}
