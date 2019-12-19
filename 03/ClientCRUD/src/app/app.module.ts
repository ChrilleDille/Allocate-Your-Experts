import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ListExpertsComponent } from './experts/list-experts.component';
import { CreateExpertComponent } from './experts/create-expert.component';
import { ExpertService } from './experts/expert.service';
import { ErrorService } from './helpers/error-service';

import { ExpertDetailsComponent } from './experts/expert-details.component';
import { HomeComponent } from './home/home.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'experts-list', component: ListExpertsComponent },
  { path: 'experts-create/:id', component: CreateExpertComponent },
  { path: 'experts-details/:id', component: ExpertDetailsComponent }

];

@NgModule({
  declarations: [
    AppComponent,
    ListExpertsComponent,
    CreateExpertComponent,
    ExpertDetailsComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpClientModule
  ],
  providers: [ExpertService, ErrorService],
  bootstrap: [AppComponent]
})
export class AppModule { }
