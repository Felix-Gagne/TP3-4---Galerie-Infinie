import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Galery } from '../Models/Galery';
import { GalleryServices } from '../services/gallery-services';
import { ImageServices } from '../services/image-services';
import { Image } from '../Models/image';

declare var Masonry : any;
declare var imagesLoaded : any;

@Component({
  selector: 'app-myGalleries',
  templateUrl: './myGalleries.component.html',
  styleUrls: ['./myGalleries.component.css']
})
export class MyGalleriesComponent implements OnInit {

  @ViewChild("myPictureViewChild", {static:false}) pictureInput ?: ElementRef;
  @ViewChild("newCoverPicture", {static:false}) newCoverInput ?: ElementRef;
  @ViewChild("addPicture", {static:false}) addPictureInput ?: ElementRef;

  @ViewChild("masongrid") masongrid ?: ElementRef;
  @ViewChildren("masongriditems") masongriditems ?: QueryList<any>;

  name : string = "";
  isPublic : boolean = false;
  defaultImage : string = "/assets/images/galleryThumbnail.png";

  galeries : Galery[] = [];

  galeryId : number = 0;
  galeryName : string = "";

  username : string = "";

  imageId : number = 0;

  images : Image[] = [];


  constructor(public http : HttpClient, public service : GalleryServices, public iService : ImageServices) { }

  async ngOnInit() 
  {
    this.galeries = await this.service.getMyGaleries();
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

  async createNewGalery(){
    await this.service.newGalery(this.name, this.isPublic, this.pictureInput);
    this.galeries = await this.service.getMyGaleries();
  }

  async makeGalleryPublic(){
    await this.service.makePublic(this.galeryId);
    this.galeries = await this.service.getMyGaleries();
  }

  async makeGalleryPrivate(){
    await this.service.makePrivate(this.galeryId);
    this.galeries = await this.service.getMyGaleries();
  }

  async addAllowedUser(){
    await this.service.addUser(this.galeryId, this.username);
    this.galeries = await this.service.getMyGaleries();
  }

  async deleteGallery(){
    await this.service.deleteGalery(this.galeryId);
    this.galeries = await this.service.getMyGaleries();
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
  }

  async addImageToGalery(){
    if(this.addPictureInput != undefined){
      await this.iService.addPicture(this.addPictureInput, this.galeryId);
      await this.getGaleryInfo(this.galeryId, this.galeryName);
    }
  }

  getImageId(id : number){
    this.imageId = id;
    console.log(this.imageId);
  }

  async deleteImages(){
    await this.iService.deletePicture(this.imageId, this.galeryId);
    await this.getGaleryInfo(this.galeryId, this.galeryName);
  }

  async changeCover():Promise<any>{
    await this.service.changeCover(this.galeryId, this.newCoverInput);
    this.galeries = await this.service.getMyGaleries();
  }
}
