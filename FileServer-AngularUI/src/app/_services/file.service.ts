import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {File} from '../_models/file';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  constructor(private httpClient: HttpClient) {
  }

  getFiles(): File[] {
    const filesFromServer: File[] = [];
    filesFromServer.push({ name: 'test1.doc', type: 'word'});
    filesFromServer.push({ name: 'test2.docx', type: 'word'});
    filesFromServer.push({ name: 'test3.xls', type: 'excel'});
    filesFromServer.push({ name: 'test4.xlsx', type: 'excel'});
    filesFromServer.push({ name: 'test5.jpg', type: 'image'});
    filesFromServer.push({ name: 'test6.png', type: 'image'});
    filesFromServer.push({ name: 'test7.jpeg', type: 'image'});
    filesFromServer.push({ name: 'test8.pdf', type: 'pdf'});
    filesFromServer.push({ name: 'test9.zip', type: 'zip'});
    filesFromServer.push({ name: 'test10.edoc', type: 'unknown'});
    filesFromServer.push({ name: 'test11.mp4', type: 'video'});
    filesFromServer.push({ name: 'test12.exe', type: 'unknown'});

    return filesFromServer;
  }
}
