import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { CryptService } from './crypt.service';

@Injectable({
  providedIn: 'root',
})
export class AuthRouteGuardService implements CanActivate {
  user = {
    roles: '',
    name: '',
  };
  constructor( private rout: Router,   private crypt: CryptService) {}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | boolean
    | UrlTree
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree> {

      const get = JSON.parse(
        this.crypt.Decrypt(localStorage.getItem('token')!)
      );
      this.user.roles = get.role;
      this.user.name = get.nameUser;

    if (get) {
      console.log(get.role);
      if (get.role.toLowerCase() != 'admin') {
        this.rout.navigate(['accessdenied']).then((x) => {
          window.location.reload();
        });
      }
      return true;
    } else {

        this.rout.navigate(['notfound']).then((x) => {
          window.location.reload();
        });

    }
    return false;
  }
}
