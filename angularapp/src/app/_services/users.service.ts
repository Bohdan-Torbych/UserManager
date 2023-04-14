import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { User } from '../_models/user';
import { map, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  baseUrl = environment.apiUrl;
  users: User[] = [];

  constructor(private http: HttpClient) { }

  getUsers() {
    if (this.users.length > 0) return of(this.users);
    return this.http.get<User[]>("/users").pipe(
        map((users) => {
          this.users = users;
          return users;
        })
      );
  }
}
