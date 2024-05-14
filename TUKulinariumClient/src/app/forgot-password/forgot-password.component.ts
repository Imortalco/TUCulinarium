import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { FormControl, FormControlName, Validators } from '@angular/forms';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css'],
})
export class ForgotPasswordComponent {
  emailControl: FormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  constructor(private authService: AuthService) {}

  sendRecoverCode() {
    if (this.emailControl.valid) {
      const email = this.emailControl.value;
      console.log(email);
      return this.authService.forgotPasswordAction(email);
    } else {
      console.log(this.emailControl.errors);
      return -1;
    }
  }
}
