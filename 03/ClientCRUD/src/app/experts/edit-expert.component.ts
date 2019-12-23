import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ExpertService} from './expert.service';
import {Expert} from '../models/expert.model';

@Component({
  selector: 'app-edit-expert',
  templateUrl: './edit-expert.component.html',
  styleUrls: ['./edit-expert.component.css']
})
export class EditExpertComponent implements OnInit {
constructor(private _service: ExpertService,
  private _actRoute: ActivatedRoute,
  private _router: Router) { }

  expert: Expert = {
    id: null,
    firstName: null,
    lastName: null,
    email: null,
    gender: null
  }
 

  private getExpert(){
    this._actRoute.params.subscribe(
      params => {
        const id = params['id'];       
        this._service.getSingle(id).subscribe(data => {
          this.expert = data;
        });
      }
    )
  }

  onSubmit(){
    this._service.update(this.expert.id, this.expert).subscribe(data =>{
      this._router.navigate(['expert-details', data.id]);
    });
  }

  ngOnInit() {
    this.getExpert();
  }

}
