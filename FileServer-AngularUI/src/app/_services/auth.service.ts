import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {JwtHelperService} from '@auth0/angular-jwt';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:6048/api/auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private httpClient: HttpClient) {
  }

  login(userCreds: any) {
    return this.httpClient.post(this.baseUrl + 'login', userCreds).pipe(
      map((response: any) => {
        const tokenObj = response;
        if (tokenObj) {
          localStorage.setItem('token', tokenObj.token);
          this.decodedToken = this.jwtHelper.decodeToken(tokenObj.token);
        }
      })
    );
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
