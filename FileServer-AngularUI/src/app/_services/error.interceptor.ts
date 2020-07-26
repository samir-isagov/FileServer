import {Injectable} from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor, HTTP_INTERCEPTORS, HttpErrorResponse
} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError} from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor() {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(httpErrorResponse => {
        if (httpErrorResponse.status === 401) {
          return throwError(httpErrorResponse.statusText);
        }

        if (httpErrorResponse instanceof HttpErrorResponse) {
          const appError = httpErrorResponse.headers.get('Application-Error');
          if (appError) {
            return throwError(appError);
          }

          const srvError = httpErrorResponse.error;
          let modelStateErrors = '';
          if (srvError.errors && typeof srvError.errors === 'object') {
            for (const key in srvError.errors) {
              if (srvError.errors[key]) {
                modelStateErrors += srvError.errors[key] + '\n';
              }
            }
          }

          return throwError(modelStateErrors || srvError || 'Server işləmir və ya xəta baş verdi! :(');
        }
      })
    );
  }
}

export const ErrorInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: ErrorInterceptor,
  multi: true
};
