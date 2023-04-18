import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { Galery } from '../Models/Galery';
import { RegisterDTO } from '../Models/RegisterDTO';
import { UserServices } from '../services/user-services';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  username : string = "";
  email : string = "";
  password : string = "";
  passwordConfirm : string = "";


  constructor(public router : Router, public http : HttpClient, public service : UserServices) { }

  ngOnInit() {
  }

  async register(){
    await this.service.register(this.username, this.email, this.password, this.passwordConfirm);
    await this.service.login(this.username, this.password);
  }
}
