import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'Open Library';
  users: any;

  constructor(private accountService: AccountService) {}

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const userFromLocalStorage = localStorage.getItem('user');
    const user: User =
      userFromLocalStorage !== null ? JSON.parse(userFromLocalStorage) : null;
    this.accountService.setCurrentUser(user);
  }
}
