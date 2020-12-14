import { Component, OnInit } from '@angular/core';
import { AuthService } from './../services/auth.service';
import { User } from '../models/User';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  message: string;

  currentUser: User;

  constructor(private authService: AuthService){
    this.authService.currentUser.subscribe(user => this.currentUser = user);
  }

  ngOnInit(): void {
    this.message = `Welcome, ${this.currentUser.firstName}`;
  }

}
