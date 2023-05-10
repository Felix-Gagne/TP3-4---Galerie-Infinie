import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Galery } from "../Models/Galery";
import { lastValueFrom } from 'rxjs';
import { ElementRef, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class GalleryServices {

    constructor(public http : HttpClient){}

    async newGalery(name : string, isPublic : boolean, pictureInput ?: ElementRef) : Promise<void>
    {
        if(pictureInput == undefined){
          console.log("Input HTML non charger.");
          return;
        }
        let file = pictureInput.nativeElement.files[0];
        if(file == null){
          console.log("Input HTML ne contient aucune image.")
          return;
        }

        let formData = new FormData();

        formData.append("monImage", file, file.name);
        formData.append("galeryName", name);
        formData.append("isPublic", isPublic.toString());
    
        let x = await lastValueFrom(this.http.post<any>("https://localhost:7219/api/Galery/PostGalery", formData));
        console.log(x);
      }
    
      async getMyGaleries() : Promise<Galery[]>
      {
          let x = await lastValueFrom(this.http.get<Galery[]>("https://localhost:7219/api/Galery/GetGalery"));
          console.log(x);
        
          let galeries : Galery[]

          galeries = x;

          return galeries;
      }
    
      async deleteGalery(galeryId : number) : Promise<void>{
        let x = await lastValueFrom(this.http.delete<Galery>("https://localhost:7219/api/Galery/DeleteGalery/" + galeryId));
      }
    
      async addUser(galeryId : number, username : string) : Promise<void>{
        let x = await lastValueFrom(this.http.put<Galery>("https://localhost:7219/api/Galery/AddUser/" + galeryId + "/" + username, null));
      }
    
      async makePublic(galeryId : number) : Promise<void>{
        let x = await lastValueFrom(this.http.put<Galery>("https://localhost:7219/api/Galery/MakePublic/" + galeryId, null));
      }
    
      async makePrivate(galeryId : number) : Promise<void>{
        let x = await lastValueFrom(this.http.put<Galery>("https://localhost:7219/api/Galery/MakePrivate/" + galeryId, null));
      }

}
