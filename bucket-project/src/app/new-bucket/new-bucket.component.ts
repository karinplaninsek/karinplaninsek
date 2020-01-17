import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Bucket } from '../bucket.model';
import { BucketService } from '../bucket.service';
import { ApiService } from '../api.service';
import { Locations } from '../locations.model';

@Component({
  selector: 'app-new-bucket',
  templateUrl: './new-bucket.component.html',
  styleUrls: ['./new-bucket.component.css']
})
export class NewBucketComponent implements OnInit {

  loadedLocations: any;
  bucketLocation: any;
  bucketLocation1: any;
  bucketId: any;
  bucketId1: any;

  bucket =  {
    id: String,
    name: String,
    location: {
      id: String,
      name: String
    }
  };

  headers = new HttpHeaders({ Authorization: `Token ${'53023857-8748-4C14-8283-CBA98E4D1011'}`,
                              'Content-Type': 'application/json'});

  @Output() bucketAdded = new EventEmitter<Bucket>();

  constructor(private bucketService: BucketService,
              private apiService: ApiService,
              private http: HttpClient) { }

  ngOnInit() {
    this.apiService.getLocationData()
      .subscribe((loadedLocations) => {
        this.loadedLocations = loadedLocations;
        console.log(loadedLocations);

        // getting access to array of locations in api response
        loadedLocations = loadedLocations["locations"];
        // getting access to location name in index 0
        let location = loadedLocations[0];
        let locationId = location['id'];
        let locationName = location['name'];
        console.log(locationName, locationId);

        this.bucketLocation = locationName;
        this.bucketId = locationId;

        // getting access of location name on index 1
        let location1 = loadedLocations[1];
        let locationId1 = location1['id'];
        let locationName1 = location1['name'];
        console.log(locationName1);

        this.bucketLocation1 = locationName1;
        this.bucketId1 = locationId1;

      });

  }

  createBucket(form: NgForm) {
    const value = form.value;
    const newBucket =  new Bucket (value.id, value.name, value.location);



    // document.getElementById('id').innerHTML = newBucket.bucketName;

    // this.loadedLocations = this.apiService.loadedLocations;

    this.bucketAdded.emit(newBucket);
    this.bucketService.createBucket(newBucket);

    this.bucket.id = form.controls['name'].value;
    this.bucket.name = form.controls['name'].value;
    this.bucket.location.name = form.controls['location'].value;

    if (document.getElementById('location').innerHTML === 'Kranj') {
      this.bucket.location.id = this.bucketId;
    } else if (document.getElementById('location').innerHTML === 'Ljubljana') {
      this.bucket.location.id = this.bucketId1;
    }

    /*this.http.post<{ [id: string]: Bucket }>(this.apiService.bucketApiUrl, newBucket, {headers: this.headers})
      .subscribe((resp) => {
        console.log(resp);
      });*/
    this.apiService.postBucketData(this.bucket)
      .subscribe((resp) => {
        console.log('Success', resp);
      }),
      error => console.log('Error ', error);

    form.reset();
  }


}
