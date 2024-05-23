import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { AuthService } from './services/auth.service';
import { CookieService } from 'ngx-cookie-service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomePageComponent } from './home-page/home-page.component';
import { AuthPageComponent } from './auth-page/auth-page.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavbarComponent } from './navbar/navbar.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { DishCardComponent } from './dish-card/dish-card.component';
import { MenuComponent } from './menu/menu.component';
import { DishDetailsComponent } from './dish-details/dish-details.component';
import { CartComponent } from './cart/cart.component';
import { ContactComponent } from './contact/contact.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    RegisterPageComponent,
    HomePageComponent,
    AuthPageComponent,
    NavbarComponent,
    ForgotPasswordComponent,
    UserProfileComponent,
    DishCardComponent,
    MenuComponent,
    DishDetailsComponent,
    CartComponent,
    ContactComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
  ],
  providers: [AuthService, CookieService],
  bootstrap: [AppComponent],
})
export class AppModule {}
