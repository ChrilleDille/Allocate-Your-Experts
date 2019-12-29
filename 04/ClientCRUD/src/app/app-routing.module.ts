import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListExpertsComponent } from './experts/list-experts.component';
import { ExpertDetailsComponent } from './experts/expert-details.component';
import { CreateExpertComponent } from './experts/create-expert.component';
import { HomeComponent } from './home/home.component';
import { EditExpertComponent } from './experts/edit-expert.component';


const routes: Routes = [
  { path: 'expert-details/:id', component: ExpertDetailsComponent },
  { path: 'expert-edit/:id', component: EditExpertComponent },
  { path: 'experts', component: ListExpertsComponent },
  { path: 'expert-create', component: CreateExpertComponent },
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }