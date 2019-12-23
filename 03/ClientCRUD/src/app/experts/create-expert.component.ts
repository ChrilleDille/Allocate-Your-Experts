import { Component, OnInit } from '@angular/core';
import { ExpertCreate } from '../models/expertCreate.model';
import { ExpertService } from './expert.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  templateUrl: './create-expert.component.html',
  styleUrls: ['./create-expert.component.css']
})
export class CreateExpertComponent implements OnInit {
  constructor(private _service: ExpertService,
    private _router: Router,
    private _actRoute: ActivatedRoute) { }

  expert: ExpertCreate = {
    firstName: null,
    lastName: null,
    email: null,
    gender: null
  }

    onSubmit(){
      this._service.create(this.expert).subscribe(data => {
        this._router.navigate(['/expert-details', data.id]);
      });
    }

  // onSubmit(): void {

  //   const id = this._activatedRoute.snapshot.params['id'];
  //   if (id === 0 || id === null) {
  //     this._service.create(this.expert).subscribe(data => {
  //       this._router.navigate(['/experts', data.id])
  //     },
  //       errResp => {
  //         this.errorMessages = [];
  //         this._errorService.listCreationErrors(errResp, this.errorMessages);
  //       });
  //   }
  //   else {
  //     this._service.update(id, this.expert).subscribe(data => {
  //       this._router.navigate(['/experts', data.id])
  //     },
  //       errResp => {
  //         this.errorMessages = [];
  //         this._errorService.listCreationErrors(errResp, this.errorMessages);
  //       });
  //   }
  // }

  ngOnInit() {
   }



}
