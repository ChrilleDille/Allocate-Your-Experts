import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
// import { ExpertForCreation } from '../models/expertForCreation.model';
import {Expert} from '../models/expert.model';
import {ExpertService} from './expert.service';
import {Router} from '@angular/router'; 
import{CreateExpert} from '../models/createExpert.model';

@Component({
  templateUrl: './create-expert.component.html',
  styleUrls: ['./create-expert.component.css']
})
export class CreateExpertComponent implements OnInit {
  expert: CreateExpert = {
    firstName: null,
    lastName: null,
    email: null,
    gender: null
  }
 
  constructor(private _expertService: ExpertService,
    private _router: Router) { }

  ngOnInit() {
  }
 
}
