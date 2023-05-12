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
        let formData = new FormData();
        formData.append("galeryName", name);
        formData.append("isPublic", isPublic.toString());
        
        try{
          if(pictureInput == undefined){
            console.log("Input HTML non charger.");
            return;
          }
          let file = pictureInput.nativeElement.files[0];
  
          formData.append("monImage", file, file.name);
      
          let x = await lastValueFrom(this.http.post<any>("https://localhost:7219/api/Galery/PostGalery", formData));
          console.log(x);
        }
        catch{
          let x = await lastValueFrom(this.http.post<any>("https://localhost:7219/api/Galery/PostGalery", formData));
          console.log(x);
        }
        
      }
    
      async getMyGaleries() : Promise<Galery[]>
      {
          let x = await lastValueFrom(this.http.get<Galery[]>("https://localhost:7219/api/Galery/GetGalery"));
          console.log("test", x);

          return x;
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

      async changeCover(id : number, pictureInput ?: ElementRef)
      { 
          if(pictureInput == undefined){
            console.log("Input HTML non charger.");
            return;
          }
          if(pictureInput == null){
            console.log("Veuillez choisir une nouvelle image.")
            return;
          }
          let formData = new FormData();
          let file = pictureInput.nativeElement.files[0];
  
          formData.append("monImage", file, file.name);
      
          let x = await lastValueFrom(this.http.put<any>("https://localhost:7219/api/Galery/ChangeCoverPicture/" + id, formData));
          console.log(x);
        }
}
