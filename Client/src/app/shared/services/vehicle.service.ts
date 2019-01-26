import {Vehicle, Car, Boat, VehicleType, CurrentVehicle, VehicleProps} from '../model/vehicle.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DataService } from './data.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
    baseUrl = 'http://localhost:63643/api/vehicles';
    private vehicleList: Vehicle[];


constructor(private http: HttpClient, private dataservice: DataService) { }


  getVehicleTypes() {
    const vehicleTypes = this.http.get<string[]>(this.baseUrl + '/types');
    return vehicleTypes;
  }

  getAllVehicles(): Observable<Vehicle[]> {
    return this.http.get<Vehicle[]>(this.baseUrl);
  }
  getVehicleProps(type: string) {
    this.http.get(this.baseUrl + '/' + type).pipe(
      map(
        (response: Response) => {
          return response;
        }))
      .subscribe(
        (response: any) => {
          this.dataservice.setVehicleProps(response);
        }
    );
  }

  addVehicle(newVehicle: Vehicle): Observable<any> {
    return this.http.post<any>(this.baseUrl + '/add', newVehicle);

  }

  updateVehicle(updateVehicle: Vehicle): Observable<string> {
    return this.http.put<string>(this.baseUrl + '/update', updateVehicle);
  }

  getVehicle(retrievevehicle: CurrentVehicle): Observable<Vehicle> {
     return this.http.post<Vehicle>(this.baseUrl + '/get/', retrievevehicle);
  }


}
