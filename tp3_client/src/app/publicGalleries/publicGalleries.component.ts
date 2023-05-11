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

  galeryId : number = 0;

  galeryName : String = "";

  constructor(public http : HttpClient) { }

  async ngOnInit() 
  {
    await this.getPublicGaleries();
  }

  async getPublicGaleries() : Promise<void>{
    let x = await lastValueFrom(this.http.get<Galery[]>("https://localhost:7219/api/Galery/GetPublicGaleries"));
    console.log(x);
    this.galeries = x;
  }

  async getGaleryInfo(id : number, name : string)
  {
    this.galeryId = id;
    this.galeryName = name;
    console.log(this.galeryId, this.galeryName);
  }


}
