import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-show-person',
  templateUrl: './show-person.component.html',
  styleUrls: ['./show-person.component.css']
})
export class ShowPersonComponent implements OnInit {

  constructor() { }

  @Input() person:any;
  PersonId:string="";
  PersonFirstName:string="";
  PersonMiddleName:string="";
  PersonLastName:string="";
  PersonPhoneNumber:string="";
  PersonAdress:string="";
  
  ngOnInit(): void {
    this.PersonId = this.person.PersonId;
    this.PersonFirstName = this.person.PersonFirstName;
    this.PersonMiddleName = this.person.PersonMiddleName;
    this.PersonLastName = this.person.PersonLastName;
    this.PersonPhoneNumber = this.person.PersonPhoneNumber;
    this.PersonAdress = this.person.PersonAdress;
  }
}
