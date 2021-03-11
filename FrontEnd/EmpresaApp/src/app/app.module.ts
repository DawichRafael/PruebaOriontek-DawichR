import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ClientesComponent } from './clientes/clientes.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
@NgModule({
  declarations: [
    AppComponent,
    ClientesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatSidenavModule
    ],
    exports:[
      MatToolbarModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
