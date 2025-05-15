import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Modules/Layout/header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainModule } from './Modules/main/main.module';


@NgModule({
  declarations: [
    AppComponent,
    
  ],

 imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MainModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
