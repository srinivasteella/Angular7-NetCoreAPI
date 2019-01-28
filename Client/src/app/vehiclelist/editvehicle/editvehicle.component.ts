import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { VehicleService } from '../../shared/services/vehicle.service';
import {CurrentVehicle, Vehicle} from '../../shared/model/vehicle.model';
import { DataService } from '../../shared/services/data.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-editvehicle',
  templateUrl: './editvehicle.component.html',
  styleUrls: ['./editvehicle.component.css']
})
export class EditvehicleComponent implements OnInit, OnDestroy {
  editablevehicle: CurrentVehicle;
  vehicleforedit: any;
  private subscription: Subscription;
  vehicleProps: any[];
  bindablevehicle: any[];
  editform: FormGroup;
  IdProp = ['Id', 'VehicleType'];


  constructor(private route: ActivatedRoute, private router: Router, private vehicleService: VehicleService,
    private dataService: DataService) {
    this.route.params
    .subscribe(
      (params: Params) => {
        this.editablevehicle = new CurrentVehicle(+params['id'], params['type']);
      }
    );
    this.vehicleService.getVehicleProps(this.editablevehicle.VehicleType.toString());

  }

  ngOnInit() {

    this.subscription = this.dataService.vehiclePropsChanged
    .subscribe(
      (vlist: any) => {
        this.getProperties(vlist);
      }
    );

  }

  buildForm(arrayProps) {
    const formGroup = {};
    for (const prop of Object.values(arrayProps)) {
      formGroup[prop['Name']] = new FormControl(prop['Value']);
    }
    formGroup['VehicleType'] = new FormControl(this.editablevehicle.VehicleType.toString());
    formGroup['Id'] = new FormControl(this.editablevehicle.Id);

    this.editform = new FormGroup(formGroup);
  }

  getProperties(data) {
    this.vehicleProps = this.excludeParams(data);

    this.vehicleService.getVehicle(this.editablevehicle.VehicleType.toString(), this.editablevehicle.Id)
       .subscribe(vehicleData => {
         this.vehicleProps.forEach(element => {
           element['Value'] = vehicleData[element['Name']];
         });

         this.bindablevehicle = this.vehicleProps;
         this.buildForm(this.bindablevehicle);
       }) ;


  }

  excludeParams(arrInput) {
    const desiredProps = arrInput.filter(d => !this.IdProp.includes(d.Name));
    return desiredProps;
  }

    onSubmit() {
      this.vehicleService.updateVehicle(this.editform.value).subscribe(data => {
      });

    this.router.navigate(['']);
  }

  cancel() {
    this.router.navigate(['']);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
