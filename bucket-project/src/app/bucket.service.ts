import { Bucket } from './bucket.model';
import { Subject } from 'rxjs';

export class BucketService {

  bucketsChanged = new Subject<Bucket[]>();

  private buckets: Bucket[] = [
    new Bucket('BesStorage', 'Kranj'),
    new Bucket('Pics', 'Ljubljana')
  ];

  getBuckets() {
    return this.buckets.slice();
  }

  getBucket(index: number) {
    return this.buckets[index];
  }

  createBucket(bucket: Bucket) {
    this.buckets.push(bucket);
    this.bucketsChanged.next(this.buckets.slice());
  }

  createBuckets(buckets: Bucket[]) {
    this.buckets.push(...buckets);
    this.bucketsChanged.next(this.buckets.slice());
  }
}
