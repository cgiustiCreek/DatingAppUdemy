import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_Services/auth.service';
import { subscribeOn, take } from 'rxjs/operators';
import { AlertifyService } from '../_Services/alertify.service';
import { RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.css']
})
export class NavComponent implements OnInit {
 model: any = {};

 constructor(public authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  Login(){
    this.authService.Login(this.model).subscribe(next => {
      this.alertify.success('Logged in successfully');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/member']);
    });
  }

  LoggedIn(){
    return this.authService.LoggedIn();
  }

  LogOut(){
    localStorage.removeItem('token');
    this.alertify.message('Loge Out');
    this.router.navigate(['/home']);
  }
}
