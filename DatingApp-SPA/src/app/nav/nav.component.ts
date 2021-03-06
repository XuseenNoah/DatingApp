import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }
  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success("Successfully Logged In");
      this.router.navigate(['/members']);
      this.model = {};
    }, error => {
      this.alertify.error("Invalid Login");
      this.model = {};

    })
  }

  loggedIn() {

    return this.authService.loggedIn();
  }
  loggedOut() {
    localStorage.removeItem('token');
    this.alertify.message("Succesfully Logged Out");
    this.router.navigate(['/home']);
  }

}
