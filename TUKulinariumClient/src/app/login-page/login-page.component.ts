import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ForgotPasswordComponent } from '../forgot-password/forgot-password.component';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css'],
})
export class LoginPageComponent {
  loginForm: FormGroup;
  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router,
    private ngbModal: NgbModal,
    private cookieService: CookieService
  ) {
    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  onLogin() {
    const email = this.loginForm.get('email').value;
    const password = this.loginForm.get('password').value;
    if (this.loginForm.valid) {
      return this.authService.signIn(email, password).subscribe(
        (response) => {
          console.log(response);
          localStorage.setItem('username', email);
          this.cookieService.set('Auth-cookie', email);
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

  openDialog() {
    const modalRef = this.ngbModal.open(ForgotPasswordComponent);
  }
}
