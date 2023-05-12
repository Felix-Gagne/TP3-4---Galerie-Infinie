import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Galery } from '../Models/Galery';
import { Image } from '../Models/image';
import { ImageServices } from '../services/image-services';

@Component({
  selector: 'app-publicGalleries',
  templateUrl: './publicGalleries.component.html',
  styleUrls: ['./publicGalleries.component.css']
})
export class PublicGalleriesComponent implements OnInit {

  galeries : Galery[] = [];

  galeryId : number = 0;

  galeryName : String = "";

  images : Image[] = [];

  constructor(public http : HttpClient, public iService : ImageServices) { }

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

    if(this.images == null){
      this.images = await this.iService.getPictures(this.galeryId);
    }
    else{
      this.images = [];
      this.images = await this.iService.getPictures(this.galeryId);
    }

    console.log(this.galeryId, this.galeryName);
  }
}
