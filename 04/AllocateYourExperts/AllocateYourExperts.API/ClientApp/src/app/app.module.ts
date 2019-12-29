import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ListExpertsComponent } from './experts/list-experts.component';
import { ExpertService } from './experts/expert.service';
import { CreateExpertComponent } from './experts/create-expert.component';

const appRoutes: Routes = [
    { path: 'experts', component: ListExpertsComponent },
    { path: 'experts/create', component: CreateExpertComponent }
   
  ];


@NgModule({
    declarations: [
        AppComponent,
        ListExpertsComponent,
        CreateExpertComponent,

    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot(appRoutes)
    ],
    providers: [ExpertService],
    bootstrap: [AppComponent]
})
export class AppModule { }
