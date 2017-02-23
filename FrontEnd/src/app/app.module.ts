import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header.component';
import { DropdownDirective } from './dropdown.directive';
import { SearchComponent } from './search/search.component';
import { ViewAllComponent } from './view-all/view-all.component';
import { EmployeeService } from './employee.service';
import { AddNewEmployeeComponent } from './add-new-employee/add-new-employee.component';
import { routing } from './app.routing';
import { HomeComponent } from './home/home.component';
import { LoginService } from './login.service';
import { LoginComponent } from './login.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    DropdownDirective,
    SearchComponent,
    ViewAllComponent,
    AddNewEmployeeComponent,
    HomeComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    ReactiveFormsModule,
    routing
  ],
  providers: [EmployeeService,LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
