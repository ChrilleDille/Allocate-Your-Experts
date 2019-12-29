import { Component, OnInit } from '@angular/core';
import { ExpertService } from '../experts/expert.service';
import { Expert } from '../models/expert.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-expert-details',
  templateUrl: './expert-details.component.html',
  styleUrls: ['./expert-details.component.css']
})
export class ExpertDetailsComponent implements OnInit {

  constructor(private _service: ExpertService,
    private _activatedRoute: ActivatedRoute,
    private _router: Router) { }

  expert: Expert;

  private getExpert() {
    this._activatedRoute.params.subscribe(
      params => {
        const id = params['id'];
        this._service.getSingle(id).subscribe(data => {
         this.expert = data;
        });
      }
    )
  }

  private btnEditClick() {
    this._router.navigate(['/expert-edit', this.expert.id]);
  }

  btnRemoveClick(){
    this._service.delete(this.expert.id, this.expert).subscribe(data => {
      this._router.navigate(['/experts']);
    });
  }

  ngOnInit() {
    this.getExpert();
  }

}
