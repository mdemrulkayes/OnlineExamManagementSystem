import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Environment } from '../../_environment/environment';
import { IUserRegister } from '../../_models/authentication/userRegister';

@Injectable()
export class AuthenticationService {

  constructor(private _http: HttpClient, private _env: Environment) { }

  login(username: string, password: string) {
    return this._http.post<any>(`${this._env.baseUrl}/Accounts/Login`, { Email: username, Password: password })
      .pipe(map(user => {
        if (user && user.auth_token) {
          localStorage.setItem('userAuthToken', user.auth_token);
          localStorage.setItem('name', user.Name);
          localStorage.setItem('email', user.Email);
        }
        return user;
      }));
  }


  register(userData: IUserRegister) {
    return this._http.post<any>(`${this._env.baseUrl}/Accounts/Register`, userData);
  }

  logout() {
    localStorage.removeItem('userAuthToken');
    localStorage.removeItem('name');
    localStorage.removeItem('email');
  }
}
