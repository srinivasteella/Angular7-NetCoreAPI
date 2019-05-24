import { Component, OnInit } from '@angular/core';
import {VehicleService} from '../shared/services/vehicle.service';
import {VehicleType} from '../shared/model/vehicle.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  vehicletypes;
  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {

    this.vehicleService.getVehicleTypes().subscribe(data => {
      this.vehicletypes = data;
    });  }

}
