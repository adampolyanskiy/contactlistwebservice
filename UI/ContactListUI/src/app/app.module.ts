import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PeopleComponent } from './people/people.component';
import { ShowPeopleComponent } from './people/show-people/show-people.component';
import { AddEditPeopleComponent } from './people/add-edit-people/add-edit-people.component';

@NgModule({
  declarations: [
    AppComponent,
    PeopleComponent,
    ShowPeopleComponent,
    AddEditPeopleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
