import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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

  ngOnInit(): void {
    this.form = new FormBuilder().group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required]]
    });
  }

  enviaLogin() {
    
  }
}
