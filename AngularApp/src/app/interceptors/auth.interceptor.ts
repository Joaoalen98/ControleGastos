import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { tap } from "rxjs";
import { ToastService } from "../services/bootstrap/toast.service";

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {

    constructor() { }

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        const token = JSON.parse(localStorage.getItem('token')!) || "";
        const reqClone = req.clone({
            headers: req.headers.set('Authorization', `Bearer ${token}`),
        })

        return next.handle(reqClone)
            .pipe(
                tap({
                    next: (val) => val,
                    error: (val: HttpErrorResponse) => {
                        if (val.status == 403 || val.status == 401) {
                            localStorage.removeItem('token');
                            localStorage.removeItem('usuario');
                        }
                    }
                })
            );
    }
}