import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
 isAuthenticated: string;
  constructor(private authservice: AuthService, private router: Router) {
    this.authservice.currentUser.subscribe(x => this.isAuthenticated = x);
    console.log(this.isAuthenticated);
   }

  ngOnInit() {

  }

  logout() {
    this.authservice.logout();
    this.router.navigate(['signin']);
}

}
