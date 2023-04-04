import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { User } from '../Models/User';
import { Galery } from '../Models/Galery';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  username : string = "";
  email : string = "";
  password : string = "";
  galeries : Galery[] = [];
  error : boolean = true;


  constructor(public router : Router, public http : HttpClient) { }

  ngOnInit() {
  }

  register(){

    try
    {
      this.postUser();
      // Aller vers la page de connexion
      this.router.navigate(['/login']);
    }
    catch
    {
      this.error = true;
    }
  }

  async postUser() : Promise<void>{

    let newUser = new User(0, this.username, this.email, this.password, this.galeries);

    let x = await lastValueFrom(this.http.post<User>("https://localhost:7219/api/Users/PostUser", newUser));

    console.log(x);
  }
}
