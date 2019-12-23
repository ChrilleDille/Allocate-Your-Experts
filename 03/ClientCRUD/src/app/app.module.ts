import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ListExpertsComponent } from './experts/list-experts.component';
import { CreateExpertComponent } from './experts/create-expert.component';
import { ExpertService } from './experts/expert.service';
import {MessageService} from './messages/message.service';
import { ExpertDetailsComponent } from './experts/expert-details.component';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { EditExpertComponent } from './experts/edit-expert.component';
import { MessagesComponent } from './messages/messages.component';



@NgModule({
  declarations: [
    AppComponent,
    ListExpertsComponent,
    CreateExpertComponent,
    ExpertDetailsComponent,
    HomeComponent,
    EditExpertComponent,
    MessagesComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [ExpertService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
