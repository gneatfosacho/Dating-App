import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from '@angular/router';
import {Observable} from 'rxjs/Observable';
import {ProfileService} from '../_services/profile.service';

@Injectable()
export class ProfileResolverService implements Resolve<any>{

  constructor(private profileService: ProfileService) { }

  resolve(route: ActivatedRouteSnapshot) {
    return this.profileService.getProfile(route.params['id']);
  }

}
