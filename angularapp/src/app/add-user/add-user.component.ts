import { Component, ViewChild } from '@angular/core';
import { FormControl, NgForm, Validators } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { RegisterUser } from '../_models/register-data';
import { map } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

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

  constructor(
    private accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {
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
    result.subscribe({
      next: () => {
        this.router.navigateByUrl('/');
        // this.toastr.success('Successfuly user added');
      },
      error: () => {
        // this.toastr.error('Error user added');
        // TODO add toastr notification
        // this.user = {
        //   fullName: '',
        //   email: '',
        //   gender: '',
        //   dob: new Date(),
        //   password: '',
        // };
      },
    });
  }
}
