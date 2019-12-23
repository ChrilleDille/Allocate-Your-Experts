import { Component, OnInit } from '@angular/core';
import { Expert } from '../models/expert.model';
import { ExpertService } from './expert.service';
import {Router} from '@angular/router';



@Component({
  templateUrl: './list-experts.component.html',
  styleUrls: ['./list-experts.component.css']
})

export class ListExpertsComponent implements OnInit {
  
  experts: Expert[] = [];
  constructor(private _expertService: ExpertService,
    private _router: Router) { }

 onClick(id: string){
    this._router.navigate(['/expert-details', id]);
  }

 toCreate(){
    this._router.navigate(['/expert-create']);
  }

  private getExperts() {
    this._expertService.getAll().subscribe(data => {
      this.experts = data;
    });
  }

  ngOnInit() {
    this.getExperts();
  }
}


