import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { HeaderComponent } from '../Layout/header/header.component';
import { BrowserModule } from '@angular/platform-browser';
import { MatToolbarModule } from '@angular/material/toolbar'; // Import correcto de MatToolbarModule
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';

import {MatButtonModule} from '@angular/material/button';





@NgModule({
  declarations: [
    HeaderComponent
  ],
  imports: [
     CommonModule,
    MainRoutingModule,
    MatToolbarModule,
    MatIconModule,
    MatMenuModule,
    MatButtonModule
  ]
  ,exports: [
    HeaderComponent
  ]
})
export class MainModule { }
