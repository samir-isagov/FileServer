import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {CollapseModule} from 'ngx-bootstrap/collapse';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {AccordionModule} from 'ngx-bootstrap/accordion';

import {AppComponent} from './app.component';
import {HeaderComponent} from './header/header.component';
import {DirectoriesComponent} from './directories/directories.component';
import {FilesComponent} from './files/files.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    DirectoriesComponent,
    FilesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    AccordionModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
