import { Injectable } from '@angular/core';
import { BaseApiService } from './base-api.service';
import { NovaMovimentacaoModel } from './interfaces/nova-movimentacao.model';
import { Movimentacao } from 'src/app/interfaces/movimentacao.model';
import { CategoriasModel } from './interfaces/categorias.model';

@Injectable({
  providedIn: 'root'
})
export class MovimentacaoService extends BaseApiService {
  obter(params: any) {
    return this.http.get<Movimentacao[]>(this.url + `api/v1/movimentacao`, {
      params
    });
  }

  criar(model: NovaMovimentacaoModel) {
    return this.http.post(this.url + "api/v1/movimentacao", model);
  }

  editar(model: Movimentacao) {
    return this.http.put(this.url + "api/v1/movimentacao", model);
  }

  deletar(id: string) {
    return this.http.delete(this.url + "api/v1/movimentacao/" + id);
  }

  obterCategorias() {
    return this.http.get<CategoriasModel>(this.url + "api/v1/movimentacao/categorias");
  }
}
