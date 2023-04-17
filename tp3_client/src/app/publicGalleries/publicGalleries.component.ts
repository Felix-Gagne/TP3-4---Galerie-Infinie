import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Galery } from '../Models/Galery';

@Component({
  selector: 'app-publicGalleries',
  templateUrl: './publicGalleries.component.html',
  styleUrls: ['./publicGalleries.component.css']
})
export class PublicGalleriesComponent implements OnInit {

  galeries : Galery[] = [];

  constructor(public http : HttpClient) { }

  async ngOnInit() 
  {
    await this.getPublicGaleries();
  }

  async getPublicGaleries() : Promise<void>{
    
    let token = localStorage.getItem("token");

    let httpOptions = {
      headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
      })
    };

    let x = await lastValueFrom(this.http.get<Galery[]>("https://localhost:7219/api/Galery/GetPublicGaleries", httpOptions));
    console.log(x);
    this.galeries = x;
  }

}
