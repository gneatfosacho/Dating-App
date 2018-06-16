import {Routes} from '@angular/router';
import {AppComponent} from './app.component';
import {ListsComponent} from './lists/lists.component';
import {MessagesComponent} from './messages/messages.component';
import {HomeComponent} from './home/home.component';
import {LoginComponent} from './accounts/login/login.component';
import {ProfileComponent} from './profile/profile.component';
import {RegisterComponent} from './accounts/register/register.component';
import {AuthGuard} from './_guards/auth.guard';
import {ProfileResolverService} from './_resolvers/profile-resolver.service';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
  { path: 'lists', component: ListsComponent, canActivate: [AuthGuard]},
  { path: 'messages', component: MessagesComponent, canActivate: [AuthGuard]},
  { path: 'login', component: LoginComponent},
  { path: 'profile/:id', component: ProfileComponent, resolve: {profile: ProfileResolverService}, canActivate: [AuthGuard]},
  { path: 'register', component: RegisterComponent},
  { path: '', redirectTo: 'home', pathMatch: 'full'}
];
