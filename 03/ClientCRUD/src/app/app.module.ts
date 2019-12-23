import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { ListExpertsComponent } from './experts/list-experts.component';
import {ExpertService} from './expert.service';
import {MessageService} from './message.service';
import { MessagesComponent } from './messages/messages.component';
import { ExpertDetailComponent } from './experts/expert-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    ListExpertsComponent,
    MessagesComponent,
    ExpertDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [ExpertService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
