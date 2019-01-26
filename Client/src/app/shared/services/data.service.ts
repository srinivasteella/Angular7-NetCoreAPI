import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { VehicleProps, Vehicle } from '../model/vehicle.model';

@Injectable()
export class DataService {
  vehiclePropsChanged = new Subject<VehicleProps[]>();
  vehicleProps: VehicleProps[];
  constructor() {}
  setVehicleProps(_vehicleProps: any) {
    this.vehicleProps = _vehicleProps;
    this.vehiclePropsChanged.next(this.vehicleProps.slice());
  }
 getVehicleProps() {
    return this.vehicleProps;
  }

}
