import {Component, OnInit} from '@angular/core';
import {ProfileService} from '../_services/profile.service';
import {ActivatedRoute} from '@angular/router';
import {AccountService} from '../_services/account.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  profile: any;
  editMode = false;

  constructor(private profileService: ProfileService,
              private route: ActivatedRoute,
              private accountService: AccountService) {
  }

  ngOnInit() {
    //this.profile = this.route.snapshot.data['profile'];
    this.route.data.subscribe(data => {
      this.profile = data['profile'];
    });
  }

  toggleEditMode() {
    this.editMode = !this.editMode;
  }

  updateProfile() {
    console.log(this.profile);

    this.profileService.updateProfile(this.accountService.currentUser.id, this.profile).subscribe(data => {
      console.log('profile updated successfully');
      this.editMode = false;
    });
  }

}
