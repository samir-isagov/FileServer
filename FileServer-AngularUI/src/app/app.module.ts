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
import {FormsModule} from '@angular/forms';
import {AuthService} from './_services/auth.service';
import {AlertifyService} from './_services/alertify.service';
import {RouterModule} from '@angular/router';
import {ErrorInterceptor} from './_services/error.interceptor';
import {appRoutes} from './routes';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { FileServerComponent } from './file-server/file-server.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    DirectoriesComponent,
    FilesComponent,
    HomeComponent,
    FileServerComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    BsDropdownModule.forRoot(),
    AccordionModule.forRoot(),
    FormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [AuthService, AlertifyService, ErrorInterceptor],
  bootstrap: [AppComponent]
})
export class AppModule {
}
