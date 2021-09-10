import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-people',
  templateUrl: './show-people.component.html',
  styleUrls: ['./show-people.component.css']
})
export class ShowPeopleComponent implements OnInit {

  constructor(private service:SharedService) { }

  ngOnInit(): void {
    this.refreshPeopleList();
  }

  PeopleList:any=[];

  refreshPeopleList() {
    this.service.getPeopleList().subscribe(data => {
      this.PeopleList = data;
    });
  }

}
