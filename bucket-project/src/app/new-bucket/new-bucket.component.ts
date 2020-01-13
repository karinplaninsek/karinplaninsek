import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { Bucket } from '../bucket.model';
import { BucketService } from '../bucket.service';

@Component({
  selector: 'app-new-bucket',
  templateUrl: './new-bucket.component.html',
  styleUrls: ['./new-bucket.component.css']
})
export class NewBucketComponent implements OnInit {

  @Output() bucketAdded = new EventEmitter<Bucket>();

  constructor(private bucketService: BucketService) { }

  ngOnInit() {
  }

  createBucket(form: NgForm) {
    const value = form.value;
    const newBucket = new Bucket(value.name, value.location);

    this.bucketAdded.emit(newBucket);
    this.bucketService.createBucket(newBucket);

    form.reset();
  }

}
