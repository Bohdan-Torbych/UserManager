import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginData } from '../_models/login-data';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  loginInfo : LoginData;

  constructor(private router: Router, private accountService: AccountService){
    this.loginInfo = {
      email : "",
      password : ""
    }
  }

  login(){
    console.log(this.loginInfo);
    let result = this.accountService.login(this.loginInfo);
    result.subscribe(
      res => {
        console.log("res");
        console.log(res)},
      error => console.log(error)
    );
    // TODO: cleaning form after submit
    // this.router.navigateByUrl("/")
  }
}
