import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddComponent } from './addvehicle/addvehicle.component';
//import { BrowserModule } from '@angular/platform-browser';
import { VehicleRoutingModule } from './vehicle-routing.module';
import { VehiclelistComponent } from './vehiclelist.component';
import { EditvehicleComponent } from './editvehicle/editvehicle.component';
import { CommonModule } from '@angular/common';
import { HomeComponent } from '../home/home.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
        HomeComponent,
        AddComponent,
        VehiclelistComponent,
        EditvehicleComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    //BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    VehicleRoutingModule
    ]
})
export class VehicleListModule { }
