import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { HeaderModule } from '../header/header.module';
import { PageNotFoundComponent } from '../page-not-found/page-not-found.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        HttpClientModule,
        HeaderModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent,
        PageNotFoundComponent
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule { }
