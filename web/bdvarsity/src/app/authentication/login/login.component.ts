import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/shared/_services/authentication/authentication.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  constructor(private _formBuilder: FormBuilder, private _route: ActivatedRoute,
    private _router: Router, private _authService: AuthenticationService, private _spinner: NgxSpinnerService) { }

  loginform = true;
  recoverform = false;
  form: FormGroup;
  errorMessage = '';

  ngOnInit(): void {
    this.form = this._formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this._authService.logout();
  }

  onSubmit() {
    this.errorMessage = '';
    this._spinner.show();
    if (this.form.invalid) {
      this.errorMessage = 'Please fill up all fields';
      this._spinner.hide();
      return;
    }

    this._authService.login(this.form.controls.username.value, this.form.controls.password.value)
      .subscribe(data => {
        if (data) {
          this._router.navigate(['/portal']);
        }
      }, err => {
        this.errorMessage = 'Invalid login. Please try again';
        this._spinner.hide();
      });
  }

  showRecoverForm() {
    this._router.navigate(['/authentication/forgot_password']);
  }

  closeErrorMessage() {
    this.errorMessage = '';
  }
}
