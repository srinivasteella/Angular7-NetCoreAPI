import { Pipe, PipeTransform } from '@angular/core';
import {VehicleType} from '../model/vehicle.model';
@Pipe({
  name: 'custompipe'
})
export class CustompipePipe implements PipeTransform {

  transform(value: any) {
    return VehicleType[value];
  }

}
