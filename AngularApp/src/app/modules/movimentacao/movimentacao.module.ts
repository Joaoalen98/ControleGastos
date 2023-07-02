import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MovimentacaoRoutingModule } from './movimentacao-routing.module';
import { ReceitasComponent } from './components/receitas/receitas.component';
import { DespesasComponent } from './components/despesas/despesas.component';
import { ModalMovimentacaoComponent } from './components/modal-movimentacao/modal-movimentacao.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ReceitasComponent,
    DespesasComponent,
    ModalMovimentacaoComponent,
  ],
  imports: [
    CommonModule,
    MovimentacaoRoutingModule,
    ReactiveFormsModule,
    SharedModule,
  ]
})
export class MovimentacaoModule { }
