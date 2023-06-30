import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioRoutingModule } from './usuario-routing.module';
import { LoginComponent } from './components/login/login.component';
import { CadastroComponent } from './components/cadastro/cadastro.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { SpinnerComponent } from 'src/app/shared/components/spinner/spinner.component';


@NgModule({
  declarations: [
    LoginComponent,
    CadastroComponent,
    SpinnerComponent,
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule,
    NgbModule,
    FormsModule,
  ]
})
export class UsuarioModule { }
