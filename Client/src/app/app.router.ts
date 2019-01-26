
import {Routes, RouterModule, CanActivateChild} from '@angular/router';
import { NgModule } from '@angular/core';
import { ErrorComponentComponent } from './error-component/error-component.component';
import {VehiclelistComponent} from './vehiclelist/vehiclelist.component';
import {AddComponent} from './vehiclelist/addvehicle/addvehicle.component';
import {EditvehicleComponent} from './vehiclelist/editvehicle/editvehicle.component';

import {HomeComponent} from './home/home.component';

const appRoute: Routes = [
  {path: '', component: HomeComponent, children: [ {path: '', component: VehiclelistComponent},
  {path: 'Edit/:type/:id', component: EditvehicleComponent}]},
  {path: 'Add/:type', component: AddComponent},
  {path: '**', component: ErrorComponentComponent, data: {message: 'Page not found'} }
];

@NgModule ({
  imports: [
    RouterModule.forRoot(appRoute)
  ],
  exports: [RouterModule]
})

export class AppRoutingModule {

}
