import { Component, OnInit } from '@angular/core';
import {AuthService} from '../_services/auth.service';
import {Router} from '@angular/router';
import {AlertifyService} from '../_services/alertify.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  isCollapsed = true;
  isUserCollapsed = true;

  userTemplate: any = {};

  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) {
  }

  ngOnInit(): void {
  }

  login() {
    this.authService.login(this.userTemplate).subscribe(next => {
      this.alertify.success('Uğurla daxil oldunuz!');
    }, error => {
      this.alertify.error(error);
    }, ()=>{
      this.router.navigate(['/file-server']);
    });
  }

  logOut() {
    localStorage.removeItem('token');
    this.alertify.message('Hesabdan çıxış olundu');
    this.router.navigate(['/']);
  }

  loggedIn() {
    return this.authService.loggedIn();
  }
}
