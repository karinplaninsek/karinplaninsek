import { Files } from './bucket/file.model';
import { Subject } from 'rxjs';

export class FileService {

  filesChanged = new Subject<Files[]>();

  private files: Files[] = [
    new Files('FileName01', '01.09.2019', 2)
  ];

  getFile(index: number) {
    return this.files[index];
  }

  getFiles() {
    return this.files.slice();
  }

  createFile(file: Files) {
    this.files.push(file);
    this.filesChanged.next(this.files.slice());
  }

  createFiles(files: Files[]) {
    this.files.push(...files);
    this.filesChanged.next(this.files.slice());
  }
}
