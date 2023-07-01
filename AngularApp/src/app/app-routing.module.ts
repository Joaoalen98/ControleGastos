import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'usuario/login',
    pathMatch: 'full'
  },
  {
    path: 'usuario',
    loadChildren: () => import('./modules/usuario/usuario.module').then(x => x.UsuarioModule),
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./modules/dashboard/dashboard.module').then(x => x.DashboardModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'movimentacao',
    loadChildren: () => import('./modules/movimentacao/movimentacao.module').then(x => x.MovimentacaoModule),
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
