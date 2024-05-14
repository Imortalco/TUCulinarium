import { Component, Input } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { User } from '../models/User';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css'],
})
export class RegisterPageComponent {
  @Input() isActive: boolean = false;
  signUpForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService
  ) {
    this.signUpForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      cPassword: ['', Validators.required],
      fName: ['', Validators.required],
      lName: ['', Validators.required],
      phone: ['', Validators.pattern(/^(\+\d{1,3})?\s?(\d{3,})$/)],
      address: new FormControl(''),
    });
  }

  onSignUp(): void {
    const user = new User(
      this.signUpForm.get('username').value,
      this.signUpForm.get('email').value,
      this.signUpForm.get('password').value,
      this.signUpForm.get('cPassword').value,
      this.signUpForm.get('fName').value,
      this.signUpForm.get('lName').value,
      this.signUpForm.get('phone').value,
      this.signUpForm.get('address').value
    );

    if (this.signUpForm.valid) {
      this.authService.signUp(user).subscribe(
        () => {
          alert('Registration successful! You can now log in.');
        },
        (error) => {
          console.error('Signup failed:', error);
          alert('Registration failed! Please try again.');
        }
      );
    }
  }
}
