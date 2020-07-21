import {Component, OnInit} from '@angular/core';
import {FileService} from '../_services/file.service';

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.css']
})
export class FilesComponent implements OnInit {
  files: any = [];

  constructor(private filesService: FileService) {
  }

  ngOnInit(): void {
    this.files = this.filesService.getFiles();
  }
}
