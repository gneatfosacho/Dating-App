import { Component, OnInit } from '@angular/core';
import {AccountService} from '../../_services/account.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};

  constructor(private accountService: AccountService, private router:Router) { }

  ngOnInit() {
  }

  register() {
    console.log(this.model);
    this.accountService.register(this.model).subscribe(
      data => {
        this.router.navigate(['/login']);
      },
      error => {
        console.log('error in registering');
      }
    )
  }

  cancel(){
    this.router.navigate(['/login']);
  }

}
