import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { CookieService } from 'ngx-cookie-service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css'],
})
export class LoginPageComponent {
  loginForm: FormGroup;
  constructor(
    private authService: AuthService,
    private cookieService: CookieService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  onLogin() {
    const email = this.loginForm.get('email').value;
    const password = this.loginForm.get('password').value;
    console.log(email, password);
    if (this.loginForm.valid) {
      return this.authService.signIn(email, password).subscribe(
        (response) => {
          console.log(response);
          this.router.navigate(['/home']);
        },
        (error) => {
          alert('Error when logging in. Check your credentials.');
          console.log(error);
        }
      );
    } else {
      alert('Error when logging in. Check your credentials.');
      return this.loginForm.errors;
    }
  }

  storeCookies(headers: HttpHeaders): void {
    const cookies = headers.getAll('Set-Cookie');
    cookies.forEach((cookie) => {
      this.cookieService.set(
        cookie.split(';')[0],
        cookie.split(';')[0].split('=')[1]
      );
    });
  }
}
