import { Component, OnInit, AfterViewInit, OnDestroy } from '@angular/core';
import {Vehicle, Car} from '../shared/model/vehicle.model';
import { VehicleService } from '../shared/services/vehicle.service';
import { Subscription } from 'rxjs';
import { timeout } from 'q';


@Component({
  selector: 'app-vehiclelist',
  templateUrl: './vehiclelist.component.html',
  styleUrls: ['./vehiclelist.component.css']
})
export class VehiclelistComponent implements OnInit, OnDestroy {
  vehicleList: Vehicle[];
  private subscription: Subscription;
  public Loading = false;
  constructor(private vehicleService: VehicleService) {
   }

  ngOnInit() {
    this.Loading = true;
    setTimeout(() => {
      this.subscription = this.vehicleService.getAllVehicles().subscribe(data => {
        this.vehicleList = data;
        this.Loading = false;
        });
    }, 1000);
   }

   ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
