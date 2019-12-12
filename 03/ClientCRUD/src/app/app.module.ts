import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

import { AppComponent } from './app.component';
import { ListExpertsComponent } from './experts/list-experts.component';
import { CreateExpertComponent } from './experts/create-expert.component';

const appRoutes: Routes = [
  {path: 'experts', component: ListExpertsComponent},
  {path: 'experts/create', component: CreateExpertComponent},
  // {path: '', redirectTo: '/list', pathMatch: 'full'}
];

@NgModule({
  declarations: [
    AppComponent,
    ListExpertsComponent,
    CreateExpertComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
