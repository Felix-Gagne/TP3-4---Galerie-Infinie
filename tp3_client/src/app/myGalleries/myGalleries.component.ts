
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Galery } from '../Models/Galery';

@Component({
  selector: 'app-myGalleries',
  templateUrl: './myGalleries.component.html',
  styleUrls: ['./myGalleries.component.css']
})
export class MyGalleriesComponent implements OnInit {

  name : string = "";
  isPublic : boolean = false;
  defaultImage : string = "/assets/images/galleryThumbnail.png";

  galeries : Galery[] = [];


  constructor(public http : HttpClient) { }

  async ngOnInit() 
  {
    await this.getMyGaleries();
    console.log("La liste : " + this.galeries);
    console.log(this.galeries[0].name);
  }

  async newGalery() : Promise<void>{

    let token = localStorage.getItem("token");

    console.log("Token : ", token);
    
    let httpOptions = {
      headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
      })
    };

    console.log("bearer : ", httpOptions);

    let galery = new Galery(0, this.name, this.isPublic, this.defaultImage);

    console.log("Galery : ", galery);

    let x = await lastValueFrom(this.http.post<any>("https://localhost:7219/api/Galery/PostGalery", galery, httpOptions));
    console.log(x);

    await this.getMyGaleries();
  }

  async getMyGaleries() : Promise<void>
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
      this.galeries = x;
  }

}
