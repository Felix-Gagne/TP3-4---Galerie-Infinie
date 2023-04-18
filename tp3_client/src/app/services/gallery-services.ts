import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Galery } from "../Models/Galery";
import { lastValueFrom } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class GalleryServices {

    constructor(public http : HttpClient){}

    async newGalery(name : string, isPublic : boolean, defaultImage : string) : Promise<void>{

        let token = localStorage.getItem("token");
    
        console.log("Token : ", token);
        
        let httpOptions = {
          headers : new HttpHeaders({
            'Content-Type' : 'application/json',
            'Authorization' : 'Bearer ' + token
          })
        };
    
        console.log("bearer : ", httpOptions);
    
        let galery = new Galery(0, name, isPublic, defaultImage);
    
        console.log("Galery : ", galery);
    
        let x = await lastValueFrom(this.http.post<any>("https://localhost:7219/api/Galery/PostGalery", galery, httpOptions));
        console.log(x);
      }
    
      async getMyGaleries() : Promise<Galery[]>
      {
          let token = localStorage.getItem("token");
    
          let httpOptions = {
            headers : new HttpHeaders({
              'Content-Type' : 'application/json',
              'Authorization' : 'Bearer ' + token
            })
          };
    
          let x = await lastValueFrom(this.http.get<Galery[]>("https://localhost:7219/api/Galery/GetGalery", httpOptions));
          console.log(x);
        
          let galeries : Galery[]

          galeries = x;

          return galeries;
      }
    
      async deleteGalery(galeryId : number) : Promise<void>{
    
        let token = localStorage.getItem("token");
    
        let httpOptions = {
          headers : new HttpHeaders({
            'Content-Type' : 'application/json',
            'Authorization' : 'Bearer ' + token
          })
        };
    
        let x = await lastValueFrom(this.http.delete<Galery>("https://localhost:7219/api/Galery/DeleteGalery/" + galeryId, httpOptions));
      }
    
      async addUser(galeryId : number, username : string) : Promise<void>{
        
        let token = localStorage.getItem("token");
    
        console.log(token);
    
        let httpOptions = {
          headers : new HttpHeaders({
            'Content-Type' : 'application/json',
            'Authorization' : 'Bearer ' + token
          })
        };
    
        let x = await lastValueFrom(this.http.put<Galery>("https://localhost:7219/api/Galery/AddUser/" + galeryId + "/" + username, null, httpOptions));
    
      }
    
      async makePublic(galeryId : number) : Promise<void>{
    
        let token = localStorage.getItem("token");
    
        let httpOptions = {
          headers : new HttpHeaders({
            'Content-Type' : 'application/json',
            'Authorization' : 'Bearer ' + token
          })
        };
    
        let y : boolean = true;
    
        let x = await lastValueFrom(this.http.put<Galery>("https://localhost:7219/api/Galery/MakePublic/" + galeryId, null, httpOptions));
      }
    
      async makePrivate(galeryId : number) : Promise<void>{
    
        let token = localStorage.getItem("token");
    
        let httpOptions = {
          headers : new HttpHeaders({
            'Content-Type' : 'application/json',
            'Authorization' : 'Bearer ' + token
          })
        };
    
        let y : boolean = true;
    
        let x = await lastValueFrom(this.http.put<Galery>("https://localhost:7219/api/Galery/MakePrivate/" + galeryId, null, httpOptions));
      }

}
