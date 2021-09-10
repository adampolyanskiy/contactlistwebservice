import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-people',
  templateUrl: './add-edit-people.component.html',
  styleUrls: ['./add-edit-people.component.css']
})
export class AddEditPeopleComponent implements OnInit {

  constructor(private service:SharedService) { }

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

  addPerson(){
    var val = {PeronId:this.PersonId,
      PersonFirstName:this.person.PersonFirstName,
      PersonMiddleName:this.person.PersonMiddleName,
      PersonLastName:this.person.PersonLastName,
      PersonPhoneNumber:this.person.PersonPhoneNumber,
      PersonAdress:this.person.PersonAdress
      };

      this.service.addPerson(val).subscribe(res=>{
        alert(res.toString());
      });
  }

  updatePerson(){
    var val = {PersonId:this.PersonId,
              PersonFirstName:this.person.PersonFirstName,
              PersonMiddleName:this.person.PersonMiddleName,
              PersonLastName:this.person.PersonLastName,
              PersonPhoneNumber:this.person.PersonPhoneNumber,
              PersonAdress:this.person.PersonAdress
      }
    this.service.updatePerson(val).subscribe(res=>{
      alert(res.toString());
    });
  }


};
