import { CanLoad, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router, Route } from '@angular/router';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';

import * as fromApp from '../store/app.reducers';
import * as fromAuth from './store/auth.reducers';
import { AuthService } from './auth.service';
import { map } from 'rxjs/operators';

@Injectable()
export class AuthGuard implements CanActivate, CanLoad {
  //isValidatedUser: string;

    // constructor(private authService: AuthService, private router: Router ) {

    // }

  // canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
  //   this.authService.currentUser.subscribe(x => this.isValidatedUser = x);
  //   if (this.isValidatedUser) {
  //     return true;
  //   }
  //   this.router.navigate(['signin']);
  //       return false;
  // }

  constructor(private store: Store<fromApp.AppState>, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.store.select('auth').pipe(map((authState: fromAuth.State) => {
      console.log(authState);
      if (authState.authenticated) {

        return authState.authenticated;
          }
          this.router.navigate(['signup']);
          return authState.authenticated;
    }));
  }

  canLoad(route: Route) {
    return this.store.select('auth').pipe(map((authState: fromAuth.State) => {
      if (authState.authenticated) {
        this.router.navigate(['/']);
        return authState.authenticated;
          }
          this.router.navigate(['signin']);
          return authState.authenticated;
    }));
  }
}
