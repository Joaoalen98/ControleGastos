import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ToastService } from '../services/bootstrap/toast.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard {
  constructor(
    private router: Router,
    private toastService: ToastService
  ) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const token = localStorage.getItem('token');
    if (token != null) {
      return true;
    } else 
    {
      this.toastService.show('Sua sessão expirou, faça login novamente', { classname: 'bg-danger text-white ' });
      this.router.navigate(['usuario', 'login']);
      return false;
    }
  }
  
}
