
import {Routes, RouterModule, CanActivateChild} from '@angular/router';
import { NgModule } from '@angular/core';
import {AddComponent} from './addvehicle/addvehicle.component';
import { AuthGuard } from '../auth/auth-guard.service';
import { HomeComponent } from '../home/home.component';
import { VehiclelistComponent } from './vehiclelist.component';
import { EditvehicleComponent } from './editvehicle/editvehicle.component';

const vehicleRoute: Routes = [
  {path: '', component: HomeComponent, children: [
    {path : '', component: VehiclelistComponent},
    {path: 'Edit/:type/:id', component: EditvehicleComponent},
    {path: 'Add/:type', component: AddComponent, canActivate: [AuthGuard]}
]},
];

@NgModule ({
  imports: [
    RouterModule.forChild(vehicleRoute)
  ],
  exports: [RouterModule],
  providers: [
    AuthGuard
  ]
})

export class VehicleRoutingModule {

}
