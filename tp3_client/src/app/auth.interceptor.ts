import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    if(request.url != "https://localhost:7219/api/Users/Register")
    {
      if(request.url != "https://localhost:7219/api/Users/Login")
      {
        console.log(localStorage.getItem("token"));

        request = request.clone({
          setHeaders:{
            'Authorization': 'Bearer ' + localStorage.getItem("token")
          }
        })

      }
    }
    
    return next.handle(request);
  }
}
