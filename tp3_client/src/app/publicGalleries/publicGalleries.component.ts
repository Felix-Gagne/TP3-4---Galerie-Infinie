import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Galery } from '../Models/Galery';
import { Image } from '../Models/image';
import { ImageServices } from '../services/image-services';

declare var Masonry : any;
declare var imagesLoaded : any;

@Component({
  selector: 'app-publicGalleries',
  templateUrl: './publicGalleries.component.html',
  styleUrls: ['./publicGalleries.component.css']
})
export class PublicGalleriesComponent implements OnInit {

  @ViewChild("masongrid") masongrid ?: ElementRef;
  @ViewChildren("masongriditems") masongriditems ?: QueryList<any>;

  galeries : Galery[] = [];

  galeryId : number = 0;

  galeryName : String = "";

  images : Image[] = [];

  imageId : number = 0;

  constructor(public http : HttpClient, public iService : ImageServices) { }

  async ngOnInit() 
  {
    await this.getPublicGaleries();
  }

  ngAfterViewInit() { 
        this.masongriditems?.changes.subscribe(e => { 
          this.initMasonry(); 
        }); 
      
        if(this.masongriditems!.length > 0) { 
          this.initMasonry(); 
        } 
      } 
    
      initMasonry() { 
        var grid = this.masongrid?.nativeElement; 
        var msnry = new Masonry( grid, { 
          itemSelector: '.grid-item',
          columnWidth:320, // À modifier si le résultat est moche
          gutter:3
        });
       
        imagesLoaded( grid ).on( 'progress', function() { 
          msnry.layout(); 
        }); 
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

  getImageId(id : number){
    this.imageId = id;
    console.log(this.imageId);
  }
}
