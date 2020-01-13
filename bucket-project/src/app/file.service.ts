import { File } from './bucket/file.model';
import { Subject } from 'rxjs';

export class FileService {

  filesChanged = new Subject<File[]>();

  private files: File[] = [
    new File('FileName01', '01.09.2019', 2)
  ];

  getFile(index: number) {
    return this.files[index];
  }

  getFiles() {
    return this.files.slice();
  }

  createFile(file: File) {
    this.files.push(file);
    this.filesChanged.next(this.files.slice());
  }

  createFiles(files: File[]) {
    this.files.push(...files);
    this.filesChanged.next(this.files.slice());
  }
}
