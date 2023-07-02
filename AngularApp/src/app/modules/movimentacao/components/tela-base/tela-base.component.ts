import { Component, Input, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Movimentacao } from 'src/app/interfaces/movimentacao.model';
import { CategoriasModel } from 'src/app/services/api/interfaces/categorias.model';
import { MovimentacaoService } from 'src/app/services/api/movimentacao.service';
import { ToastService } from 'src/app/services/bootstrap/toast.service';
import { ModalMovimentacaoComponent } from '../modal-movimentacao/modal-movimentacao.component';

@Component({
  selector: 'app-tela-base',
  templateUrl: './tela-base.component.html',
  styleUrls: ['./tela-base.component.scss']
})
export class TelaBaseComponent implements OnInit {
  @Input() tipoMovimentacao!: string;
  mes: number = new Date().getMonth();
  ano: number = new Date().getFullYear();
  movimentacoes?: Movimentacao[];
  categorias!: CategoriasModel;

  textCss!: string;
  btnCss!: string;
  legendaBtnAdd!: string;
  textPassados!: string;

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
    
    this.textCss = this.tipoMovimentacao == 'RECEITA' ? 'text-success' : 'text-danger';
    this.btnCss = this.tipoMovimentacao == 'RECEITA' ? 'btn btn-success' : 'btn btn-danger';
    this.legendaBtnAdd = this.tipoMovimentacao == 'RECEITA' ? 'Nova Receita' : 'Nova Despesa';  
    this.textPassados = this.tipoMovimentacao == 'RECEITA' ? 'Recebidos' : 'Pagos';
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

  pesquisaMovimentacoes(e: any) {
    this.mes = e.mes;
    this.ano = e.ano;
    this.obterMovimentacoes(e.mes, e.ano);
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
    modalRef.componentInstance.tipo = this.tipoMovimentacao;
    modalRef.componentInstance.categorias = this.tipoMovimentacao == 'RECEITA' ? this.categorias.receita : this.categorias.despesa;
    modalRef.componentInstance.movimentacao = movimentacao;
    modalRef.componentInstance.edicao = movimentacao !== undefined;

    modalRef.componentInstance.adicionadoEvent.subscribe(() => {
      this.obterMovimentacoes(this.mes, this.ano);
    });
  }

  deletaMovimentacao(id: string) {
    if (confirm('Tem certeza que deseja deletar esta movimentação?')) {
      this.movimentacaoService.deletar(id)
        .subscribe({
          next: (res) => {
            this.toastService.show('Deletado com sucesso', { classname: 'bg-success text-white' });
            this.obterMovimentacoes(this.mes, this.ano);
          },
          error: (res) => {
            this.toastService.show('Ocorreu um erro ao tentar deletar', { classname: 'bg-danger text-white' });
          }
        });
    }
  }
}
