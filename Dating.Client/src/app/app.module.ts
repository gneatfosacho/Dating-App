import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import {BsDropdownModule, TabsModule} from 'ngx-bootstrap';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import {RouterModule} from '@angular/router';
import {appRoutes} from './routes';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { LoginComponent } from './accounts/login/login.component';
import { RegisterComponent } from './accounts/register/register.component';
import {AccountService} from './_services/account.service';
import {AuthGuard} from './_guards/auth.guard';
import {ProfileService} from './_services/profile.service';
import {ProfileResolverService} from './_resolvers/profile-resolver.service';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    ListsComponent,
    MessagesComponent,
    HomeComponent,
    ProfileComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    BsDropdownModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    TabsModule.forRoot()
  ],
  providers: [
    AccountService,
    AuthGuard,
    ProfileService,
    ProfileResolverService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
