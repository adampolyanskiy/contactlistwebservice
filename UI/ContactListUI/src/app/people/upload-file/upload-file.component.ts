import { Component, OnInit} from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { ShowPeopleComponent } from '../show-people/show-people.component';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent implements OnInit {

  constructor(private service:SharedService, private showPeopleComp:ShowPeopleComponent) { }

  ngOnInit(): void {
  }

  public uploadFile = (file:any) => {
    const formData = new FormData();
    formData.append("file", new Blob(file), file.name);
  
    this.service.uploadFile(formData).subscribe( result => {
      alert(result.toString());
      this.showPeopleComp.refreshPeopleList();
    })

  }

}
