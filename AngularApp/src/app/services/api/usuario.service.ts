import { Injectable } from '@angular/core';
import { BaseApiService } from './base-api.service';
import { LoginModel } from 'src/app/areas/usuario/interfaces/login.model';
import { CadastroModel } from 'src/app/areas/usuario/interfaces/cadastro.model';
import { LoginCorretoModel } from 'src/app/areas/usuario/interfaces/login-correto.model';
import { Usuario } from 'src/app/interfaces/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService extends BaseApiService {
  login(model: LoginModel) {
    return this.http.post<LoginCorretoModel>(this.url + "api/v1/usuario/login/", model);
  }

  cadastro(model: CadastroModel) {
    return this.http.post(this.url + "api/v1/usuario/cadastro", model);
  }

  validaToken(token: string) {
    return this.http.get<Usuario>(this.url + "api/v1/usuario/valida-token", {
      headers: {
        'Authorization': `Bearer ${token}`
      }
    })
  }
}
