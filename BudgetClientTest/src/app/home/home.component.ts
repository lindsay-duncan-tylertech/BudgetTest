import { Component, OnInit } from '@angular/core';
import { AuthService } from './../services/auth.service';
import { User } from '../models/User';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  user: User;
  message: string;

  constructor(private authService: AuthService){
  }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('user'));
    this.message = `Welcome, ${this.user?.firstName}`;
  }

  isLoggedIn() {
    return this.authService.isLoggedIn();
  }

}
