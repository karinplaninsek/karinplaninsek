import { Component, OnInit } from '@angular/core';
import { File } from '../file.model';
import { Subscription } from 'rxjs';
import { FileService } from 'src/app/file.service';

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.css']
})
export class FilesComponent implements OnInit {

  // an array of files of type File model
  files: File[];
  private changeSub: Subscription;

  constructor(private fileService: FileService) { }

  ngOnInit() {

    this.files = this.fileService.getFiles();

    this.changeSub = this.fileService.filesChanged
      .subscribe((files: File[]) => {
        this.files = files;
      });
  }

}
