import { Component, OnInit } from '@angular/core';
import { ExpertCreate } from '../models/expertCreate.model';
import { Expert } from '../models/expert.model';
import { ExpertService } from './expert.service';
import { Router, ActivatedRoute } from '@angular/router';
import { stringify } from 'querystring';
import { ErrorService } from '../helpers/error-service';

@Component({
  templateUrl: './create-expert.component.html',
  styleUrls: ['./create-expert.component.css']
})
export class CreateExpertComponent implements OnInit {
  constructor(private _service: ExpertService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute,
    private _errorService: ErrorService) { }

  headerText: string;
  errorMessages: any[];
  expert: ExpertCreate = {
    firstName: null,
    lastName: null,
    email: null,
    gender: null
  }

  private getExpert(id: string) {
    if (id === '' || id === null) {
      this.expert = {
        firstName: null,
        lastName: null,
        email: null,
        gender: null
      }
      this.headerText = 'Create New';
    }
    else {
      this.headerText = 'Edit';
      this._service.getSingle(id).subscribe(data => {
        this.expert = data;
      },
        errResp => {
          this._errorService.listGetErrors(errResp);
        });
    }
  }

  onSubmit(): void {

    const id = this._activatedRoute.snapshot.params['id'];
    if (id === '' || id === null) {
      this._service.create(this.expert).subscribe(data => {
        this._router.navigate(['/experts-details', data.id])
      },
        errResp => {
          this.errorMessages = [];
          this._errorService.listCreationErrors(errResp, this.errorMessages);
        });
    }
    else {
      this._service.update(id, this.expert).subscribe(data => {
        this._router.navigate(['/experts-details', data.id])
      },
        errResp => {
          this.errorMessages = [];
          this._errorService.listCreationErrors(errResp, this.errorMessages);
        });
    }
  }

  ngOnInit() {
    this._activatedRoute.params.subscribe(
      params => {
        const id = params['id'];        
        this.getExpert(id);
      }
    );

  }



}
