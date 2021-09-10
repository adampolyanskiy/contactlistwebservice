import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl="http://localhost:5000/api";
  
  constructor(private http:HttpClient) {  }

  getPeopleList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/people');
  }

  addPerson(val:any){
    return this.http.post(this.APIUrl+'/people',val);
  }

  updatePerson(val:any){
    return this.http.put(this.APIUrl+'/people',val);
  }

  deletePerson(val:any){
    return this.http.delete(this.APIUrl+'/people/'+val);
  }

}
