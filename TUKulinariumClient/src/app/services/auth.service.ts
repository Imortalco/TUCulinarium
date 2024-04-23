import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/User';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl: string = 'https://localhost:8000/api/Auth';

  constructor(private http: HttpClient) {}

  signIn(email: string, password: string): Observable<any> {
    const signInUrl = `${this.apiUrl}/login`;
    const body = { email, password };
    console.log(body);
    return this.http.post(signInUrl, body, { withCredentials: true });
  }

  signUp(userModel: User): Observable<any> {
    const signUpUrl = `${this.apiUrl}/signup`;
    return this.http.post(signUpUrl, userModel);
  }
}
