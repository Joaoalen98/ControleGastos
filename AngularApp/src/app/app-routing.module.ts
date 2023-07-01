import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'usuario/login',
    pathMatch: 'full'
  },
  {
    path: 'usuario',
    loadChildren: () => import('./areas/usuario/usuario.module').then(x => x.UsuarioModule),
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./areas/dashboard/dashboard.module').then(x => x.DashboardModule)
  },
  {
    path: 'movimentacao',
    loadChildren: () => import('./areas/movimentacao/movimentacao.module').then(x => x.MovimentacaoModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
