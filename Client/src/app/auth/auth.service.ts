import { Router } from '@angular/router';
import * as firebase from 'firebase';
import { Injectable } from '@angular/core';
import { AlertService } from '../shared/services/alert.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { Store } from '@ngrx/store';
//import * as fromApp from './store/auth.reducers';
import * as fromApp from '../store/app.reducers';
import * as AuthActions from './store/auth.action';
@Injectable()
export class AuthService {
  token: string;
  error: string;
  userToken: BehaviorSubject<string>;
  public currentUser: Observable<string>;

  constructor(private router: Router, private alertService: AlertService, private store: Store<fromApp.AppState>)
   {
    this.userToken = new BehaviorSubject<string>(localStorage.getItem('userToken'));
    this.currentUser = this.userToken.asObservable();
  }

  signupUser(email: string, password: string) {
    firebase.auth().createUserWithEmailAndPassword(email, password)
    .then(
      response => {
        this.router.navigate(['signin']);
      }
    )
      .catch(
        (error: string) => { this.alertService.error(error); }
      );
  }

  signinUser(email: string, password: string) {
    firebase.auth().signInWithEmailAndPassword(email, password)
      .then(
        response => {
          this.store.dispatch(new AuthActions.Signin());
          firebase.auth().currentUser.getIdToken()
             .then(
            //   (token: string) => {
            //   this.router.navigate(['/']);
            //   this.alertService.success('success');
            //   this.store.dispatch(new AuthActions.SetToken(token));
            // }
              (token: string) => {this.token = token; this.alertService.success('success');
              localStorage.setItem('userToken', token);
              this.userToken.next(token);
              console.log('new' + token);
              }
            );
        }
      )
      .catch(
        (error: string) => { this.alertService.error(error); }
      );
  }




  logout() {
    localStorage.removeItem('userToken');
    this.userToken.next(null);
    firebase.auth().signOut();
    this.token = null;
  }

  getToken() {
    firebase.auth().currentUser.getIdToken()
      .then(
        (token: string) => this.token = token
      );
    return this.token;
  }

  isAuthenticated() {
    return this.token != null;
  }
}
