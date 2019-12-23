import { Component, OnInit } from '@angular/core';
import { ExpertService } from '../expert.service';

@Component({
  selector: 'app-expert-detail',
  templateUrl: './expert-detail.component.html',
  styleUrls: ['./expert-detail.component.css']
})
export class ExpertDetailComponent implements OnInit {
  constructor(private _service: ExpertService) { }

  ngOnInit() {
  }

}
