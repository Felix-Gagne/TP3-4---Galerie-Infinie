import { HttpClient, HttpHeaders } from "@angular/common/http";
import { ElementRef } from "@angular/core";
import { lastValueFrom } from "rxjs";
import { Injectable } from '@angular/core';
import { Image } from "../Models/image";

@Injectable({
    providedIn: 'root'
  })

export class ImageServices 
{   
    constructor(public http : HttpClient){}



    async addPicture(addPictureInput : ElementRef, galeryId : number) : Promise<void>
    {
        if(addPictureInput == undefined)
        {
            console.log("HTML input not loaded.")
            return;
        }

        let file = addPictureInput.nativeElement.files[0];

        if(file == null)
        {
            console.log("HTML input does not contain an image.")
            return;
        }

        let formData = new FormData();
        formData.append("monImage", file, file.name);

        let x  = await lastValueFrom(this.http.post<any>("https://localhost:7219/api/Images/addImageToGalery/" + galeryId, formData));
        console.log(x);
    }

    async getPictures(galeryId : number) : Promise<Image[]>
    {
        let x = await lastValueFrom(this.http.get<Image[]>("https://localhost:7219/api/Images/GetImages/" + galeryId));
        console.log(x);
        
        let images : Image[];

        images = x;

        console.log(images);

        return images;
    }

    async deletePicture(id : number, galeryId : number){
        let x = await lastValueFrom(this.http.delete<any>("https://localhost:7219/api/Images/DeleteImages/" + id + "/" + galeryId));
    }
}
