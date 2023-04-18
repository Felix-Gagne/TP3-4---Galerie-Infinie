
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginDTO } from '../Models/LoginDTO';
import { lastValueFrom } from 'rxjs';
import { UserServices } from '../services/user-services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username : string = "";
  password : string = "";

  constructor(public router : Router, public http : HttpClient, public service : UserServices) { }

  ngOnInit() {
  }

  async login(){
    await this.service.login(this.username, this.password);
  }

}
