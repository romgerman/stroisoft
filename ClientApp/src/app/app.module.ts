import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'

import { AppComponent } from './app.component';
import { EchoComponent } from './echo/echo.component';

import { EchoService } from './services/echo.service';

@NgModule({
  declarations: [
    AppComponent,
    EchoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule
  ],
  providers: [ EchoService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
