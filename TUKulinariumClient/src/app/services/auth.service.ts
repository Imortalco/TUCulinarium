import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/User';
import { Observable } from 'rxjs';
import { UserProfile } from '../models/UserProfile';

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

  forgotPasswordAction(email: string): Observable<any> {
    const forgotPassUrl = 'https://localhost:8000/api/auth/forgotPassword';
    const body = { email };
    return this.http.post(forgotPassUrl, body);
  }

  signOut(): Observable<any> {
    const signOutUrl = `${this.apiUrl}/logout`;
    return this.http.post(signOutUrl, '');
  }

  getUserProfile(username: string): Observable<UserProfile> {
    const getUserProfileUrl = `${this.apiUrl}/profile`;

    return this.http.get<UserProfile>(getUserProfileUrl, {
      params: { username: username },
    });
  }

  updateUserProfile(userProfile: UserProfile): Observable<any> {
    const updateUserProfileUrl = `${this.apiUrl}/update-profile`;

    return this.http.put(updateUserProfileUrl, userProfile);
  }
}
