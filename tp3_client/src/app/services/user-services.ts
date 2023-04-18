import { Injectable } from '@angular/core';
import { LoginDTO } from '../Models/LoginDTO';
import { lastValueFrom } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { RegisterDTO } from '../Models/RegisterDTO';

@Injectable({
  providedIn: 'root'
})

export class UserServices 
{

    constructor(public http : HttpClient, public router : Router){}

    async login(username : string, password : string) : Promise<void>{
    
        let loginDTO = new LoginDTO(username, password);
        let x = await lastValueFrom(this.http.post<any>("https://localhost:7219/api/Users/Login", loginDTO));
        console.log(x);
        this.router.navigate(['/publicGalleries']);
        localStorage.setItem("token", x.token);
      }

      async register(username : string, email : string, password : string, passwordConfirm : string) : Promise<void> {

        let registerDTO = new RegisterDTO(
          username,
          email,
          password,
          passwordConfirm);
  
          let x = await lastValueFrom(this.http.post<RegisterDTO>("https://localhost:7219/api/Users/Register", registerDTO))
  
          console.log(x);
  
          this.router.navigate(['/login']);
    }

    logout(){
        localStorage.removeItem("token");
        this.router.navigate(['/login']);
      }
}
