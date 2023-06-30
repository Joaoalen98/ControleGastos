import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.scss']
})
export class CadastroComponent implements OnInit {
  
  enviando = false;
  form!: FormGroup;

  get formValido () { return this.form.valid; }
  get controlNome () { return this.form.get('nome'); }
  get controlEmail () { return this.form.get('email'); }
  get controlCpf () { return this.form.get('cpf'); }
  get controlSenha () { return this.form.get('senha'); }

  ngOnInit(): void {
    this.form = new FormBuilder().group({
      nome: ['', [Validators.required]],
      email: ['', [Validators.required]],
      CPF: ['', [Validators.required]],
      senha: ['', [Validators.required]],
    });
  }
}
