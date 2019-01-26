import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app.router';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { VehiclelistComponent } from './vehiclelist/vehiclelist.component';
import {VehicleService} from './shared/services/vehicle.service';
import {DataService} from './shared/services/data.service';
import { DropdownDirective } from './shared/directive/dropdowndirective';
import { ErrorComponentComponent } from './error-component/error-component.component';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CustompipePipe } from './shared/pipes/custompipe.pipe';
import { AddComponent } from './vehiclelist/addvehicle/addvehicle.component';
import { EditvehicleComponent } from './vehiclelist/editvehicle/editvehicle.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    VehiclelistComponent,
    DropdownDirective,
    ErrorComponentComponent,
    HomeComponent,
    CustompipePipe,
    AddComponent,
    EditvehicleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [VehicleService, DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
