import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/shared/_services/authentication/authentication.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { IUserRegister } from 'src/app/shared/_models/authentication/userRegister';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html'
})
export class SignupComponent {
  registerForm: FormGroup;
  userInfo: IUserRegister;
  errorMessage: string;
  constructor(private _authService: AuthenticationService, private _fb: FormBuilder, private _router: Router) {
    this.registerForm = this._fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      password: ['', Validators.required],
      retypePass: ['', Validators.required]
    });

    this.errorMessage = '';
  }

  get submitedForm() {
    return this.registerForm.controls;
  }

  onRegister() {
    if (this.registerForm.invalid) {
      this.errorMessage = 'Please fill up all empty fields';
      return;
    }

    this.userInfo = {
      FirstName: this.submitedForm.firstName.value,
      LastName: this.submitedForm.lastName.value,
      Email: this.submitedForm.email.value,
      Password: this.submitedForm.password.value,
      PhoneNumber: this.submitedForm.phoneNumber.value,
      ReTypedPassword: this.submitedForm.retypePass.value
    };

    this._authService.register(this.userInfo).subscribe(data => {
      if (data) {
        this._router.navigate(['/authentication/registration_success']);
      }
    }, err => {
      this.errorMessage = err.error;
    });
  }

  closeErrorMessage() {
    this.errorMessage = '';
  }

}
