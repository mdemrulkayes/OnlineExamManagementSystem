import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  resetPasswordForm: FormGroup;
  errorMsg = '';
  constructor(private _fb: FormBuilder, private _spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.resetPasswordForm = this._fb.group({
      email: ['', Validators.required]
    });
  }

  onResetSubmit() {
    this._spinner.show();
    if (this.resetPasswordForm.invalid) {
      this.errorMsg = 'Please enter you email';
      this._spinner.hide();
      return;
    }
  }
}
