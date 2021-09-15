import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { saveAs } from "file-saver"

@Component({
  selector: 'app-download-file',
  templateUrl: './download-file.component.html',
  styleUrls: ['./download-file.component.css']
})
export class DownloadFileComponent implements OnInit {

  constructor(private service:SharedService) { }

  ngOnInit(): void {
  }

  returnBlob(res: any): Blob {
    return new Blob([res], {type: 'txt/csv'})
  }

  downloadFile() {
    this.service.downloadFile().subscribe(res => {
      saveAs(this.returnBlob(res), "contact_list.csv");
    });
    
  }

}
