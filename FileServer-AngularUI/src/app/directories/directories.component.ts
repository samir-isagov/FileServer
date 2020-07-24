import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-directories',
  templateUrl: './directories.component.html',
  styleUrls: ['./directories.component.scss']
})
export class DirectoriesComponent implements OnInit {
  rootIsOpen: boolean = true;
  directories: any = [];
  isFirstOpen = true;

  constructor() {
  }

  ngOnInit(): void {
    this.directories.push({folder: 'Sənəd dövriyyəsi AS', subFolders: ['Daxil olan', 'Daxili', 'Çıxan']});
    this.directories.push({folder: 'MTK', subFolders: ['inw_doc', 'int_doc', 'out_doc']});
    this.directories.push({folder: 'Pensiya AS', subFolders: ['inw_doc', 'int_doc', 'out_doc']});
  }

  toggleFolder() {
    this.rootIsOpen = false;
  }
}
