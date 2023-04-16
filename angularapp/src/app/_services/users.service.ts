import { HttpClient } from '@angular/common/http';
import { User } from '../_models/user';
import { map, of } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  users: User[] = [];

  constructor(private http: HttpClient) {}

  getUsers() {
    return this.http.get<User[]>('/users').pipe(
      map((users) => {
        this.users = users;
        return users;
      })
    );
  }
}
