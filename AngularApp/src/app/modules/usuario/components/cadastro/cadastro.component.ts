import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from 'src/app/services/api/usuario.service';
import { CadastroModel } from '../../../../services/api/interfaces/cadastro.model';
import { Router } from '@angular/router';
import { ToastService } from 'src/app/services/bootstrap/toast.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss']
})
export class CadastroComponent implements OnInit {
  form!: FormGroup;

  get formValido () { return this.form.valid; }
  get controlNome () { return this.form.get('nome'); }
  get controlEmail () { return this.form.get('email'); }
  get controlCpf () { return this.form.get('cpf'); }
  get controlSenha () { return this.form.get('senha'); }

  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private toastService: ToastService,
  ) { }

  ngOnInit(): void {
    this.form = new FormBuilder().group({
      nome: ['', [Validators.required]],
      email: ['', [Validators.required]],
      cpf: ['', [Validators.required]],
      senha: ['', [Validators.required]],
    });
  }
  
  enviaCadastro() {
    if (this.formValido) {
      const model: CadastroModel = {
        CPF: this.controlCpf?.value,
        nome: this.controlNome?.value,
        email: this.controlEmail?.value,
        senha: this.controlSenha?.value
      }

      this.usuarioService.cadastro(model)
        .subscribe({
          next: (res) => {
            this.toastService.show('Cadastro realizado com sucesso', { classname: 'bg-success text-white' });
            this.router.navigate(['usuario', 'login']);
          },
          error: (res) => {

          }
        });
    }
  }
}
