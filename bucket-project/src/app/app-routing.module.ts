import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { BucketComponent } from './bucket/bucket.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'details', component: BucketComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})

export class AppRoutingModule {}
