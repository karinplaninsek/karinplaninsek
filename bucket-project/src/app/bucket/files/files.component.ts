import { Component, OnInit } from '@angular/core';
import { Files } from '../file.model';
import { Subscription } from 'rxjs';
import { FileService } from 'src/app/file.service';
import { ApiService } from 'src/app/api.service';

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.css']
})
export class FilesComponent implements OnInit {

  // an array of files of type File model
  files: Files[];
  private changeSub: Subscription;

  fileToUpload;

  constructor(private fileService: FileService,
              private apiService: ApiService) { }

  ngOnInit() {

    this.files = this.fileService.getFiles();

    this.changeSub = this.fileService.filesChanged
      .subscribe((files: Files[]) => {
        this.files = files;
      });
  }

  getApiData() {
    this.apiService.getLocationData();
  }

  fileUpload(event) {
    /*this.fileToUpload = files.item(0);
    console.log(this.fileToUpload);
    this.fileToUpload = document.getElementById('name').getAttributeNames();
    console.log(this.fileToUpload);*/
    let reader = new FileReader();

    if (event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        document.getElementById('name');
      };
    }
  }

}
