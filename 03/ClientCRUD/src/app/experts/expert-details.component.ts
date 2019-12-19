import { Component, OnInit } from '@angular/core';
import {ExpertService} from '../experts/expert.service';
import {ErrorService} from '../helpers/error-service';
import {Expert} from '../models/expert.model';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-expert-details',
  templateUrl: './expert-details.component.html',
  styleUrls: ['./expert-details.component.css']
})
export class ExpertDetailsComponent implements OnInit {

  constructor(private _service: ExpertService,
    private _actRoute: ActivatedRoute,
    private  _router: Router,
    private _errorService: ErrorService) { }

    expert: Expert;

    btnEditClick(){
      this._router.navigate(['/experts-create', this.expert.id]);
    }

    btnRemoveClick(){
      this._service.delete(this.expert.id).subscribe(data => {
           alert('Expert was deleted');
      },
      err => {
       alert('error');
      });
      this._router.navigate(['/experts-list']);
    }

  ngOnInit() {
     const id = this._actRoute.snapshot.params['id'];
     this._service.getSingle(id).subscribe(data => {
       this.expert = data;
     },
     errResp => {
       this._errorService.listGetErrors(errResp);
     }
     )
  }

}
