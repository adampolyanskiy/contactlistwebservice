import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PeopleComponent } from './people/people.component';
import { ShowPeopleComponent } from './people/show-people/show-people.component';
import { AddEditPeopleComponent } from './people/add-edit-people/add-edit-people.component';
import { SharedService } from './shared.service';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { ShowPersonComponent } from './people/show-person/show-person.component';
import { UploadFileComponent } from './people/upload-file/upload-file.component';
import { DownloadFileComponent } from './people/download-file/download-file.component';

@NgModule({
  declarations: [
    AppComponent,
    PeopleComponent,
    ShowPeopleComponent,
    AddEditPeopleComponent,
    ShowPersonComponent,
    UploadFileComponent,
    DownloadFileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
