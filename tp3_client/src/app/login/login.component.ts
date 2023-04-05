
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginDTO } from '../Models/LoginDTO';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username : string = "";
  password : string = "";

  constructor(public router : Router, public http : HttpClient) { }

  ngOnInit() {
  }

  async login() : Promise<void>{
    
    let loginDTO = new LoginDTO(this.username, this.password);
    let x = await lastValueFrom(this.http.post<any>("https://localhost:7219/api/Users/Login", loginDTO));
    console.log(x);
    this.router.navigate(['/publicGalleries']);
    localStorage.setItem("token", x.token);
  }

}
