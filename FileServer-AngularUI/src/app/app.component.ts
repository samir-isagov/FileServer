import { Component } from '@angular/core';
import {AuthService} from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  registerMode = false;

  constructor(private authService: AuthService) {
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
