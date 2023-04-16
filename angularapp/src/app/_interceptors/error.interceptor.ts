import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error) {
          switch (error.status) {
            case 400:
              console.log('Error handler');
              console.log(error);
              if (error.error.errors) {
                const errors = error.error.errors;
                const modelStateErrors = [];
                for (const key in errors) {
                  if (errors[key]) {
                    modelStateErrors.push(errors[key]);
                  }
                }
                modelStateErrors.forEach((error) => this.toastr.error(error));
                throw modelStateErrors.flat();
              } else {
                this.toastr.error(error.error, error.status.toString());
              }
              break;
            case 401:
              this.toastr.error(error.error, error.status.toString());
              break;
            case 404:
              // this.router.navigateByUrl('/not-found');
              break;
            case 500:
              this.toastr.error(error.error.message);
              console.log(error.error);
              const navigationExtras: NavigationExtras = {
                state: { error: error.error },
              };
              // this.router.navigateByUrl('/server-error', navigationExtras);
              break;
            default:
              this.toastr.error(
                'Something unexpected went wrong. Probably API server is not ran'
              );
          }
        }
        throw error;
      })
    );
  }
}
