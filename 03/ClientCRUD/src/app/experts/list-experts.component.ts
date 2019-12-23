import { Component, OnInit } from '@angular/core';
import {Expert} from '../models/expert.model';
import {ExpertService} from '../expert.service';

@Component({
  selector: 'app-list-experts',
  templateUrl: './list-experts.component.html',
  styleUrls: ['./list-experts.component.css']
})
export class ListExpertsComponent implements OnInit {
  constructor(private _service: ExpertService) { }
  experts: Expert[];

  getExperts(): void {
    this._service.getAll().subscribe(data => {
      this.experts = data;
    });
  }
  ngOnInit() {
    this.getExperts();
  }

}
