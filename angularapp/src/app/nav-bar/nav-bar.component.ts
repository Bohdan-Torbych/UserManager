import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  isUserLogged: boolean;

  constructor(public accountService: AccountService) {
    this.isUserLogged = false;
  }

  ngOnInit(): void {}

  login() {
    this.isUserLogged = true;
  }

  logout() {
    this.isUserLogged = false;
  }
}
