import { Component, OnInit, OnDestroy } from '@angular/core';
import { Bucket } from '../bucket.model';
import { BucketService } from '../bucket.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {

  // an array of buckets of type Bucket model
  buckets: Bucket[];
  private changeSub: Subscription;
  sum: any;

  isShowed: boolean;
  bucketsClicked: boolean;
  bucketName: any;

  constructor(private bucketService: BucketService) { }

  ngOnInit() {
    this.isShowed = false;
    this.bucketsClicked = false;

    this.buckets = this.bucketService.getBuckets();

    this.sum = +this.buckets.reduce((acc, cur) => acc + Number(cur), 0);

    this.changeSub = this.bucketService.bucketsChanged
      .subscribe((buckets: Bucket[]) => {
        this.buckets = buckets;
      });
  }

  createNewBucket(): void {
    this.isShowed = !this.isShowed;
  }

  bucketDetails() {
    // this.bucketsClicked = !this.bucketsClicked;
    this.bucketName = document.getElementById('name').innerHTML;
  }

  ngOnDestroy(): void {
    this.changeSub.unsubscribe();
  }

}
