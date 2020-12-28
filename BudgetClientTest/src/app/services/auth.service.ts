import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../models/User';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loginPath = `${environment.apiUrl}/identity/login`;
  private registerPath = `${environment.apiUrl}/identity/register`;

  constructor(private http: HttpClient) {
  }

  login(data) {
    return this.http.post<any>(this.loginPath, data)
      .pipe((tap(this.setSession)));
  }

  logout() {
    localStorage.removeItem('user');
  }

  register(data): Observable<any> {
    return this.http.post(this.registerPath, data);
  }

  public isLoggedIn() {
    let user = localStorage.getItem('user');

    if (user != null) {
      return true;
    }

    return false;
  }

  private setSession(authResult) {
    localStorage.setItem('user', JSON.stringify(authResult));
  }

}
