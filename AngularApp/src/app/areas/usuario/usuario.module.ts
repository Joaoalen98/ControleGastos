import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioRoutingModule } from './usuario-routing.module';
import { LoginComponent } from './login/login.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SpinnerComponent } from 'src/app/components/global/spinner/spinner.component';
import { FormsModule } from '@angular/forms';


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
