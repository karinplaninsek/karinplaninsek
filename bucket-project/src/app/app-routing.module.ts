import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { BucketComponent } from './bucket/bucket.component';
import { FilesComponent } from './bucket/files/files.component';
import { DetailsComponent } from './bucket/details/details.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'details', component: BucketComponent },
  { path: 'files', component: FilesComponent },
  { path: 'bucket/details', component: DetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})

export class AppRoutingModule {}
