import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Locations } from './locations.model';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class ApiService  {

  public locationApiUrl = 'https://challenge.3fs.si/storage/locations';
  public bucketApiUrl = 'https://challenge.3fs.si/storage/buckets';
  /*authToken = 'https://challenge.3fs.si/storage/locations';*/
  data: any = {};
  // headers: Headers;
  loadedLocations: Locations[];

  constructor(private http: HttpClient) {

   }

   getData() {
     this.http.get(this.locationApiUrl, {headers: new HttpHeaders
      ({ Authorization: `Token ${'53023857-8748-4C14-8283-CBA98E4D1011'}` })})
      .subscribe((resp) => {
        console.log(resp);
      });
   }

   getLocationData(): Observable<any> {
     /*const header = new HttpHeaders().set(
       'Autherization',
       '53023857-8748-4C14-8283-CBA98E4D1011'
     );*/

     return this.http.get<any>(this.locationApiUrl, {headers: new HttpHeaders
        ({ Authorization: `Token ${'53023857-8748-4C14-8283-CBA98E4D1011'}` })});

   }

   getBucketData() {
     this.http.get(this.bucketApiUrl, {headers: new HttpHeaders({ Authorization: `Token ${'53023857-8748-4C14-8283-CBA98E4D1011'}`})})
      .subscribe((resp) => {
        console.log(resp);
      });
   }

   postBucketData(newBucket) {
    // this.http.post<{ name: string }>()
    return this.http.post(this.bucketApiUrl, newBucket, {headers: new HttpHeaders
      ({ Authorization: `Token ${'53023857-8748-4C14-8283-CBA98E4D1011'}`})});
   }

}

// {headers: new HttpHeaders({ Authorization: '53023857-8748-4C14-8283-CBA98E4D1011'})}
