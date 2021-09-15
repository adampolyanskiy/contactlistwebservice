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
    return this.http.post(this.APIUrl+'/people',val, {responseType: 'text'});
  }

  updatePerson(val:any){
    return this.http.put(this.APIUrl+'/people/' + val.PersonId, val, {responseType: 'text'});
  }

  deletePerson(val:any){
    return this.http.delete(this.APIUrl+'/people/'+val, {responseType: 'text'});
  }

  uploadFile(formData:any){
    return this.http.post(this.APIUrl+'/csv', formData, {responseType: 'text'});
  }

  downloadFile() {
    return this.http.get(this.APIUrl+'/csv', {responseType: 'blob'});
  }

}
