import { Component, OnInit } from '@angular/core';
import * as firebase from 'firebase';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'VehicleSaleApp';

  ngOnInit() {
    firebase.initializeApp({
      apiKey: 'AIzaSyBDYlOgM90iFLKrP11y59t80EBtRE_pj_k',
      authDomain: 'carsales-a4ba2.firebaseapp.com'
    });
  }

  onNavigate(feature: string) {
    this.title = feature;
  }
}

