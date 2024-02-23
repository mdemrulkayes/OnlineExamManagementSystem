import { Routes } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { RegistrationSuccessComponent } from './registration_success/registration-success.component';
import { ForgotPasswordComponent } from './forgorPassword/forgot-password.component';

export const AuthenticationRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
      },
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'signup',
        component: SignupComponent
      },
      {
        path: 'registration_success',
        component: RegistrationSuccessComponent
      },
      {
        path: 'forgot_password',
        component: ForgotPasswordComponent
      }
    ]
  }
];
