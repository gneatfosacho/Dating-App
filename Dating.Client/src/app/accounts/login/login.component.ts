import {Component, OnInit} from '@angular/core';
import {AccountService} from '../../_services/account.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  error: string;

  constructor(private accountService: AccountService, private router:Router) {
  }

  ngOnInit() {
  }

  login() {
    console.log(this.model);
    this.accountService.login(this.model.username, this.model.password).subscribe(data => {
        this.router.navigate(['/home']);
      },
      error => {
        this.error = "Username or password incorrect";
      });
  }

}
