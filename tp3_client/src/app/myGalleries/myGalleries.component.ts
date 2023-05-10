import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Galery } from '../Models/Galery';
import { GalleryServices } from '../services/gallery-services';
import { ImageServices } from '../services/image-services';

@Component({
  selector: 'app-myGalleries',
  templateUrl: './myGalleries.component.html',
  styleUrls: ['./myGalleries.component.css']
})
export class MyGalleriesComponent implements OnInit {

  @ViewChild("myPictureViewChild", {static:false}) pictureInput ?: ElementRef;
  @ViewChild("newCoverPicture", {static:false}) newPictureInput ?: ElementRef;
  @ViewChild("addPicture", {static:false}) addPictureInput ?: ElementRef;

  name : string = "";
  isPublic : boolean = false;
  defaultImage : string = "/assets/images/galleryThumbnail.png";

  galeries : Galery[] = [];

  galeryId : number = 0;
  galeryName : string = "";

  username : string = "";


  constructor(public http : HttpClient, public service : GalleryServices, public iService : ImageServices) { }

  async ngOnInit() 
  {
    this.galeries = await this.service.getMyGaleries();
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

  getGaleryInfo(id : number, name : string)
  {
    this.galeryId = id;
    this.galeryName = name;
    console.log(this.galeryId, this.galeryName);
  }

  async setNewGaleryCover(){
    await this.service.setCoverPicture(this.galeryId, this.newPictureInput);
    this.galeries = await this.service.getMyGaleries();
  }

  async addImageToGalery(){
    if(this.addPictureInput != undefined){
      await this.iService.addPicture(this.addPictureInput, this.galeryId);
    }
  }
}
