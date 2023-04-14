import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginInfo } from '../_models/login-info';
import { map, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class LoginsService {
  logins: LoginInfo[];

  constructor(private http: HttpClient) {
    this.logins = [];
  }

  getLogins() {
    if (this.logins.length > 0) return of(this.logins);
    return this.http.get<LoginInfo[]>('/logins').pipe(
      map((response) => {
        this.logins = response;
        return response;
      })
    );
  }
}
