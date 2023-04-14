import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { RegisterUser } from '../_models/register-data';
import { map } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css'],
})
export class AddUserComponent {
  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);
  user: RegisterUser;

  constructor(private accountService: AccountService, private router: Router) {
    this.user = {
      fullName: '',
      email: '',
      gender: '',
      dob: new Date(),
      password: '',
    };
  }

  addNewUser() {
    console.log(this.user);
    let result = this.accountService.register(this.user);
    result.subscribe(
      result => this.router.navigateByUrl("/"),
      error => {
        console.log(error)
        // Cleaning form and notification
      }
    );
  }
}
