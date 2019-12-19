import { Component, OnInit } from '@angular/core';
import { Expert } from '../models/expert.model';
import { ExpertService } from './expert.service';
import {ErrorService} from '../helpers/error-service';
import {Router} from '@angular/router';



@Component({
  templateUrl: './list-experts.component.html',
  styleUrls: ['./list-experts.component.css']
})

export class ListExpertsComponent implements OnInit {
  
  experts: Expert[] = [];
  constructor(private _expertService: ExpertService,
    private _router: Router,
    private _errorService: ErrorService) { }

  onClick(id: string){
    this._router.navigate(['/experts-details', id]);
  }

  navigate(){
    this._router.navigate(['/experts-create', '']);
  }

  getExperts() {
    this._expertService.getAll().subscribe(data => {
      this.experts = data;
    },
    errResp => {
       this._errorService.listGetErrors(errResp);
    }
    );
  }

  ngOnInit() {
    this.getExperts();
  }
}


