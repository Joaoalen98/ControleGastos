import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from 'src/app/services/api/usuario.service';
import { LoginModel } from '../../interfaces/login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  enviando = false;
  form!: FormGroup;
  
  get formValido () { return this.form.valid; }
  get controlEmail () { return this.form.get('email'); }
  get controlSenha () { return this.form.get('senha'); }

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit(): void {
    this.form = new FormBuilder().group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required]]
    });
  }

  enviaLogin() {
    if (this.formValido) {
      const model: LoginModel = { 
        email: this.controlEmail?.value, 
        senha: this.controlSenha?.value
      }

      this.usuarioService.login(model)
      .subscribe({
        next: (res) => {

        },
        error: () => {
          
        }
      });
    }
  }
}
