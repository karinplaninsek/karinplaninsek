import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  isShowed: boolean;

  constructor() { }

  ngOnInit() {
    this.isShowed = false;
  }

  createNewBucket(): void {
    this.isShowed = !this.isShowed;
  }

}
