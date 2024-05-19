import { Component } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  isLoggedIn: boolean;
  username: string;

  constructor(
    private cookieService: CookieService,
    private authService: AuthService,
    private router: Router
  ) {}
  ngOnInit(): void {
    const cookies = this.cookieService.getAll();
    const cookiesPresent = Object.keys(cookies).length > 0;
    if (!cookiesPresent) {
      this.isLoggedIn = false;
    } else {
      this.isLoggedIn = true;
    }
    console.log(this.isLoggedIn);
    this.username = localStorage.getItem('username');
  }

  onLogout(): void {
    this.authService.signOut();
    this.cookieService.deleteAll();
    localStorage.removeItem('username');
    window.location.reload();
    alert('Successfully logged out');
  }
}
