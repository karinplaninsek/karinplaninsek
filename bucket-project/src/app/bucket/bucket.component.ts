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

  constructor(private newBucket: HomeComponent) { }

  ngOnInit() {
    this.bucketDetails = this.newBucket.bucketName;
  }

}
