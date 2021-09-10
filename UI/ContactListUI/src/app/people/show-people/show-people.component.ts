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

  ModalTitle:string="";
  ActiveAddEditPeopleComp:boolean=false;
  ActiveShowPersonComp:boolean=false;
  person:any;


  addClick(){
    this.person={
      PersonId:0,
      PersonFirstName:"",
      PersonMiddleName:"",
      PersonLastName:"",
      PersonPhoneNumber:"",
      PersonAdress:""
    }
    this.ModalTitle="Добавить новый контакт";
    this.ActiveAddEditPeopleComp=true;
  }

  editClick(item:any){
    this.person=item;
    this.ModalTitle="Изменить контакт";
    this.ActiveAddEditPeopleComp=true;
  }

  deleteClick(item:any){
    if(confirm("Вы уверены, что хотите удалить контакт?")){
      this.service.deletePerson(item.PersonId).subscribe(data=>{
        alert(data.toString());
        this.refreshPeopleList();
      })
    }
  }

  closeClick(){
    this.ActiveAddEditPeopleComp=false;
    this.refreshPeopleList();
  }

  closeShowClick(){
    this.ActiveShowPersonComp=false;
  }

  showClick(item:any) {
    this.person = item;
    this.ModalTitle="Просмотр контакта";
    this.ActiveShowPersonComp=true;
  }
  
  refreshPeopleList() {
    this.service.getPeopleList().subscribe(data => {
      this.PeopleList = data;
    });
  }

}
