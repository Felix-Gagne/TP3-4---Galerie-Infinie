import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { Galery } from '../Models/Galery';
import { RegisterDTO } from '../Models/RegisterDTO';

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


  constructor(public router : Router, public http : HttpClient) { }

  ngOnInit() {
  }

  async register() : Promise<void> {

      let registerDTO = new RegisterDTO(
        this.username,
        this.email,
        this.password,
        this.passwordConfirm);

        let x = await lastValueFrom(this.http.post<RegisterDTO>("https://localhost:7219/api/Users/Register", registerDTO))

        console.log(x);

        this.router.navigate(['/login']);
  }
}
