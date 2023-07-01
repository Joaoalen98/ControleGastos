import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { tap } from "rxjs";
import { ToastService } from "../services/bootstrap/toast.service";

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {

    constructor(
        private router: Router,
        private toastService: ToastService
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        const token = localStorage.getItem('token') || "";
        const reqClone = req.clone({
            headers: req.headers.set('Authorization', `Bearer ${JSON.parse(token)}`),
        })

        return next.handle(reqClone)
            .pipe(
                tap({
                    next: (val) => val,
                    error: (val: HttpErrorResponse) => {
                        if (val.status == 403 || val.status == 401) {
                            this.toastService.show('Sua sessão expirou, faça login novamente', { classname: 'bg-danger text-white '});
                            localStorage.removeItem('token');
                            localStorage.removeItem('usuario');
                            this.router.navigate(['usuario', 'login']);
                        }
                    }
                })
            );
    }
}