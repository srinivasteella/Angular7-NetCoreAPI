
import {Routes, RouterModule, CanActivateChild, PreloadAllModules} from '@angular/router';
import { NgModule } from '@angular/core';
import { ErrorComponentComponent } from './error-component/error-component.component';
import {VehiclelistComponent} from './vehiclelist/vehiclelist.component';
//import {AddComponent} from './vehiclelist/addvehicle/addvehicle.component';
import {EditvehicleComponent} from './vehiclelist/editvehicle/editvehicle.component';

import {HomeComponent} from './home/home.component';
import { SigninComponent } from './auth/signin/signin.component';
import { SignupComponent } from './auth/signup/signup.component';
import { AuthGuard } from './auth/auth-guard.service';

const appRoute: Routes = [
  {path: '', loadChildren: './vehiclelist/vehiclelist.module#VehicleListModule'},
   //{path: '', component: HomeComponent, children: [{path : '', component: VehiclelistComponent},
   //{path: 'Edit/:type/:id', component: EditvehicleComponent}]},
  // {path: '', component: HomeComponent, children: [
  //   {path: '', component: VehiclelistComponent, canActivate: [AuthGuard]}
  // ]},
  //{path: 'Add/:type', component: AddComponent, canActivate: [AuthGuard]},
  { path: 'signup', component: SignupComponent },
  { path: 'signin', component: SigninComponent },
  {path: '**', component: ErrorComponentComponent, data: {message: 'Page not found'} }
];

@NgModule ({
  imports: [
    RouterModule.forRoot(appRoute, {preloadingStrategy: PreloadAllModules})
  ],
  exports: [RouterModule]
})

export class AppRoutingModule {

}
