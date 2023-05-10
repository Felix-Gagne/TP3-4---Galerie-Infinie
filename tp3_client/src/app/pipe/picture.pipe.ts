import { HttpClient } from '@angular/common/http';
import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { map } from 'rxjs';

@Pipe({
  name: 'picture'
})
export class PicturePipe implements PipeTransform {

  constructor(public http : HttpClient, public domSanitizer : DomSanitizer){}

  transform(value : any, args?: any): any {
    return this.http.get(value, {responseType : "blob"}).pipe(map(x =>
      this.domSanitizer.bypassSecurityTrustUrl(URL.createObjectURL(x))));
  }

}
