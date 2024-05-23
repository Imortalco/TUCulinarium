import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { AuthPageComponent } from './auth-page/auth-page.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { MenuComponent } from './menu/menu.component';
import { DishDetailsComponent } from './dish-details/dish-details.component';
import { CartComponent } from './cart/cart.component';
import { ContactComponent } from './contact/contact.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  {
    path: 'home',
    component: HomePageComponent,
  },
  {
    path: 'auth',
    component: AuthPageComponent,
  },
  {
    path:'user-profile',
    component: UserProfileComponent,
  },
  {
    path:'dishes',
    component:MenuComponent,
  },
  {
    path:'dish/:id',
    component:DishDetailsComponent
  },
  {
    path: 'cart',
    component: CartComponent,
  },
  {
    path:'contact',
    component: ContactComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
