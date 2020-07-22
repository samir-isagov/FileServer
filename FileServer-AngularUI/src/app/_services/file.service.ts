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
    filesFromServer.push({ name: 'test1.doc', type: 'word', size: "8mb", createdDate: "12.12.2020"});
    filesFromServer.push({ name: 'test2.docx', type: 'word', size: "8mb", createdDate: "12.12.2020"});
    filesFromServer.push({ name: 'test3.xls', type: 'excel', size: "8mb", createdDate: "12.12.2020"});
    filesFromServer.push({ name: 'test4.xlsx', type: 'excel', size: "8mb", createdDate: "12.12.2020"});
    filesFromServer.push({ name: 'test5.jpg', type: 'image', size: "8mb", createdDate: "12.12.2020"});
    filesFromServer.push({ name: 'test6.png', type: 'image', size: "8mb", createdDate: "12.12.2020"});
    filesFromServer.push({ name: 'test7.jpeg', type: 'image', size: "8mb", createdDate: "12.12.2020"});
    filesFromServer.push({ name: 'test8.pdf', type: 'pdf', size: "8mb", createdDate: "12.12.2020"});
    filesFromServer.push({ name: 'test9.zip', type: 'zip', size: "8mb", createdDate: "12.12.2020"});
    filesFromServer.push({ name: 'test10.edoc', type: 'unknown', size: "8mb", createdDate: "12.12.2020"});
    filesFromServer.push({ name: 'test11.mp4', type: 'video', size: "8mb", createdDate: "12.12.2020"});
    filesFromServer.push({ name: 'test12.exe', type: 'unknown', size: "8mb", createdDate: "12.12.2020"});

    return filesFromServer;
  }
}
