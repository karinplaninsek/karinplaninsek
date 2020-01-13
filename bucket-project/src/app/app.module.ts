import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { NewBucketComponent } from './new-bucket/new-bucket.component';
import { BucketService } from './bucket.service';
import { BucketComponent } from './bucket/bucket.component';
import { AppRoutingModule } from './app-routing.module';
import { FilesComponent } from './bucket/files/files.component';
import { DetailsComponent } from './bucket/details/details.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NewBucketComponent,
    BucketComponent,
    FilesComponent,
    DetailsComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [BucketService],
  bootstrap: [AppComponent]
})
export class AppModule { }
