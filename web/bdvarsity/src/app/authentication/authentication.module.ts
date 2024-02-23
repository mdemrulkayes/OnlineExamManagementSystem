import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';

import { AuthenticationRoutes } from './authentication.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RegistrationSuccessComponent } from './registration_success/registration-success.component';
import { ForgotPasswordComponent } from './forgorPassword/forgot-password.component';

@NgModule({
  imports: [
    CommonModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild(AuthenticationRoutes),
  ],
  declarations: [
    LoginComponent,
    SignupComponent,
    RegistrationSuccessComponent,
    ForgotPasswordComponent
  ]
})
export class AuthenticationModule {}
