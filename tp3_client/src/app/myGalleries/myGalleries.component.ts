import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Galery } from '../Models/Galery';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-myGalleries',
  templateUrl: './myGalleries.component.html',
  styleUrls: ['./myGalleries.component.css']
})
export class MyGalleriesComponent implements OnInit {

  name : string = "";
  isPublic : boolean = false;
  defaultImage : string = "/assets/images/galleryThumbnail.png";


  constructor(public http : HttpClient) { }

  ngOnInit() 
  {

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
  }

}
