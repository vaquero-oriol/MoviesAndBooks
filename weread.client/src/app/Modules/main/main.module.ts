import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { HeaderComponent } from '../Layout/header/header.component';
import { BrowserModule } from '@angular/platform-browser';
import { MatToolbarModule } from '@angular/material/toolbar'; // Import correcto de MatToolbarModule



@NgModule({
  declarations: [
    HeaderComponent
  ],
  imports: [
     CommonModule,
    MainRoutingModule,
    MatToolbarModule  
  ]
  ,exports: [
    HeaderComponent
  ]
})
export class MainModule { }
