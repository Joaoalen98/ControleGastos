import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioService } from 'src/app/services/api/usuario.service';
import { LoginModel } from '../../interfaces/login.model';
import { Router } from '@angular/router';
import { ToastService } from 'src/app/services/bootstrap/toast.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;

  get formValido() { return this.form.valid; }
  get controlEmail() { return this.form.get('email'); }
  get controlSenha() { return this.form.get('senha'); }

  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private toastService: ToastService
  ) { }

  ngOnInit(): void {
    this.form = new FormBuilder().group({
      email: ['', [Validators.required]],
      senha: ['', [Validators.required]],
    });
  }

  enviarLogin() {
    if (this.formValido) {

      const model: LoginModel = {
        email: this.controlEmail?.value,
        senha: this.controlSenha?.value,
      }

      this.usuarioService.login(model)
        .subscribe({
          next:(res) => {
            localStorage.setItem('usuario', JSON.stringify(res.usuario));
            localStorage.setItem('token', JSON.stringify(res.token));
            this.router.navigate(['dashboard', '']);
          },
          error: (res) => {
            this.toastService.show(res.error.msg, { classname: 'bg-danger text-white' });
          }
        });
    }
  }
}
