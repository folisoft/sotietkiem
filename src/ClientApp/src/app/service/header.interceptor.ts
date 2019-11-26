import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpRequest, HttpHandler, HttpInterceptor } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class HeaderInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (!req.url.includes('header')) {
            return next.handle(req);
        }
        console.warn('HeaderInterceptor');

        const modified = req.clone({ setHeaders: { 'X-Man': 'Wolverine' } });

        return next.handle(modified);
    }
}
