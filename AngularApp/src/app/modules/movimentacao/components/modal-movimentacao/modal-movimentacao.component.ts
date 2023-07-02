import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Movimentacao } from 'src/app/interfaces/movimentacao.model';
import { Usuario } from 'src/app/interfaces/usuario.model';
import { MovimentacaoService } from 'src/app/services/api/movimentacao.service';
import { ToastService } from 'src/app/services/bootstrap/toast.service';

@Component({
  selector: 'app-modal-movimentacao',
  templateUrl: './modal-movimentacao.component.html',
  styleUrls: ['./modal-movimentacao.component.scss']
})
export class ModalMovimentacaoComponent implements OnInit {
  @Input() edicao: boolean = false;
  @Input() tipo!: string;
  @Input() categorias: string[] = [];
  @Input() movimentacao?: Movimentacao
  @Output() adicionadoEvent = new EventEmitter();

  form!: FormGroup;

  get formValido () { return this.form.valid; }
  get controlValor () { return this.form.get('valor'); }
  get controlDescricao () { return this.form.get('descricao'); }
  get controlDataEntrada () { return this.form.get('dataEntrada'); }
  get controlCategoria () { return this.form.get('categoria'); }
  
  constructor(
    public activeModal: NgbActiveModal,
    private movimentacaoService: MovimentacaoService,
    private toastService: ToastService
  ) { }

  ngOnInit(): void {
    this.form = new FormBuilder().group({
      valor: [this.movimentacao?.valor, [Validators.required]],
      descricao: [this.movimentacao?.descricao, [Validators.required]],
      dataEntrada: [this.movimentacao?.dataEntrada.toString().split('T')[0], [Validators.required]],
      categoria: [this.movimentacao?.categoria, [Validators.required]],
    });
    console.log(this.movimentacao?.dataEntrada);
  }

  sucesso() {
    this.adicionadoEvent.emit();
  }

  adicionarMovimentacao() {
    if (this.formValido) {
      const usuario: Usuario = JSON.parse(localStorage.getItem('usuario')!);

      const model: Movimentacao = {
        id: this.movimentacao?.id ?? null!,
        usuarioId: usuario.id,
        valor: parseFloat(this.controlValor?.value),
        descricao: this.controlDescricao?.value,
        dataEntrada: this.controlDataEntrada?.value,
        categoria: this.controlCategoria?.value,
        tipo: this.tipo,
      }

      if (this.edicao) {
        this.movimentacaoService.editar(model)
          .subscribe({
            next: (res) => {
              this.toastService.show('Movimentação editada com sucesso', { classname: 'bg-success text-white' });
              this.sucesso();
              this.activeModal.dismiss();
            },
            error: (res) => {
              this.toastService.show('Ocorreu um erro ao tentar editar esta movimentação', { classname: 'bg-danger text-white' });
            }
          });
      } else {
        this.movimentacaoService.criar(model as any)
        .subscribe({
          next: (res) => {
            this.toastService.show('Adicionado com sucesso!', { classname: 'bg-success text-white' });
            this.sucesso();
            this.activeModal.dismiss();
          },
          error: (res) => {
            this.toastService.show('Erro ao adicionar movimentação!', { classname: 'bg-danger text-white' });
            console.log(res);
          }
        });
      }

    }
  }
}
