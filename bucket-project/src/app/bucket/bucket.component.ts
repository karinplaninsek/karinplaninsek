import { Component, OnInit } from '@angular/core';
import { NewBucketComponent } from '../new-bucket/new-bucket.component';
import { HomeComponent } from '../home/home.component';

@Component({
  selector: 'app-bucket',
  templateUrl: './bucket.component.html',
  styleUrls: ['./bucket.component.css']
})
export class BucketComponent implements OnInit {

  bucketDetails: any;
  isShown: boolean;

  constructor(private newBucket: HomeComponent) { }

  ngOnInit() {
    this.isShown = false;

    this.bucketDetails = this.newBucket.bucketName;
  }

  showDetails() {
    this.isShown = !this.isShown;
  }

}
