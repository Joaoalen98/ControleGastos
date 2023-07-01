import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { tap } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {

    constructor(
        private router: Router
    ) { }

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        const token = localStorage.getItem('token');
        if (token != null) {
            req.headers.set('Authorization', `Bearer ${token}`);
        }

        return next.handle(req)
            .pipe(
                tap({
                    next: (val) => val,
                    error: (val: HttpErrorResponse) => {
                        if (val.status == 403) {
                            localStorage.removeItem('token');
                            this.router.navigate(['usuario', 'login']);
                        }
                    }
                })
            );
    }
}