import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { VehicleService } from '../../shared/services/vehicle.service';
import { Subscription } from 'rxjs';
import { DataService } from '../../shared/services/data.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
@Component({
  selector: 'app-addvehicle',
  templateUrl: './addvehicle.component.html',
  styleUrls: ['./addvehicle.component.css']
})
export class AddComponent implements OnInit, OnDestroy {
  requestedvehicletype: string;
  vehicleProps: any[];
  testpropname: string;
  private subscription: Subscription;
  form: FormGroup;
  IdProp = ['Id', 'VehicleType'];


  constructor(private fb: FormBuilder, private route: ActivatedRoute,
     private router: Router, private vehicleService: VehicleService, private dataService: DataService) {

      this.route.params
      .subscribe(
        (params: Params) => {
          this.requestedvehicletype = params['type'];
        }
      );

      this.vehicleService.getVehicleProps(this.requestedvehicletype);
      }

  ngOnInit() {

      this.subscription = this.dataService.vehiclePropsChanged
      .subscribe(
        (vlist: any) => {
          this.getProperties(vlist);
          }
      );

    }

    getProperties(data) {
      this.vehicleProps = this.excludeParams(data);
      this.buildForm(this.vehicleProps);
    }

    buildForm(arrayProps) {
      const formGroup = {};
      for (const prop of Object.values(this.vehicleProps)) {
        formGroup[prop['Name']] = new FormControl(null);
      }
      formGroup['VehicleType'] = new FormControl(this.requestedvehicletype);

      this.form = new FormGroup(formGroup);
    }

    excludeParams(arrInput) {
      const desiredProps = arrInput.filter(d => !this.IdProp.includes(d.Name));
      return desiredProps;
    }
    onSubmit() {
      this.vehicleService.addVehicle(this.form.value).subscribe(data => {
      });
      this.router.navigate(['/']);
    }

    cancel() {
      this.router.navigate(['']);
    }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }



}
