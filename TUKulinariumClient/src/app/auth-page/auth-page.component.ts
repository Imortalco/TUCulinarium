import { Component } from '@angular/core';

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.css'],
})
export class AuthPageComponent {
  isSignUpActive: boolean = false;

  togglePanel() {
    this.isSignUpActive = !this.isSignUpActive;
  }
}
