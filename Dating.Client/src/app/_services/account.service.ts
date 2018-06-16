import { Injectable } from '@angular/core';
import {Http, RequestOptions, Headers, Response} from '@angular/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import {User} from '../accounts/user';

@Injectable()
export class AccountService {

  constructor(private http:Http) { }
  public currentUser: any;

  login(username: string, password: string) {
    let headers = new Headers({'Content-Type': 'application/json'});
    let options = new RequestOptions({headers: headers});
    return this.http.post('http://localhost:5000/api/users/authenticate', {username, password}, options)
      .map((response: Response) => {
        let user = response.json();
        if(user && user.token) {
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUser = user;
          console.log('user from auth: ' + this.currentUser);
        }
      });
  }

  isAuthenticated(){
    return !!this.currentUser;
  }

  logout(){
    this.currentUser = null;
    localStorage.removeItem('currentUser');
  }

  register(user: User){
    let headers = new Headers({'Content-Type': 'application/json'});
    let options = new RequestOptions({headers: headers});
    return this.http.post('http://localhost:5000/api/users/register', user, options);
  }

  checkAuth() {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
  }

}
