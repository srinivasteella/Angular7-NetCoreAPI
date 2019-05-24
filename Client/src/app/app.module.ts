import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app.router';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
//import { VehiclelistComponent } from './vehiclelist/vehiclelist.component';
import {VehicleService} from './shared/services/vehicle.service';
import {DataService} from './shared/services/data.service';
//import { DropdownDirective } from './shared/directive/dropdowndirective';
import { ErrorComponentComponent } from './error-component/error-component.component';
import { HomeComponent } from './home/home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CustompipePipe } from './shared/pipes/custompipe.pipe';
//import { AddComponent } from './vehiclelist/addvehicle/addvehicle.component';
//import { EditvehicleComponent } from './vehiclelist/editvehicle/editvehicle.component';
import { SigninComponent } from './auth/signin/signin.component';
import { SignupComponent } from './auth/signup/signup.component';
import { AuthGuard } from './auth/auth-guard.service';
import { AuthService } from './auth/auth.service';
import { AlertComponent } from './shared/alert/alert.component';
import { AlertService } from './shared/services/alert.service';
import { reducers } from './store/app.reducers';
import { StoreModule } from '@ngrx/store';
import { SharedModule } from './shared/shared.module';
//import { VehicleListModule } from './vehiclelist/vehiclelist.module';
//import { VehicleListModule } from './vehiclelist/vehiclelist.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    //VehiclelistComponent,
    //DropdownDirective,
    ErrorComponentComponent,
    //HomeComponent,
    CustompipePipe,
    //AddComponent,
    //EditvehicleComponent,
    SigninComponent,
    SignupComponent,
    AlertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    //SharedModule,
    StoreModule.forRoot(reducers)
  ],
  providers: [VehicleService, DataService, AuthGuard, AuthService, AlertService],
  bootstrap: [AppComponent]
})
export class AppModule { }
