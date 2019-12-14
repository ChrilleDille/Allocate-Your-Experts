

import { Component, OnInit } from '@angular/core';
import { Expert } from '../models/expert.model';
import { ExpertService } from './expert.service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Component({
    templateUrl: './list-experts.component.html',
    styleUrls: ['./list-experts.component.css']
})

export class ListExpertsComponent implements OnInit {
    // title = 'Let's CRUD';
    // users: UserData[]=[];

    // constructor(private dataservice: DataService){}
    // getUsers(){
    //   this.dataservice.getUsers().subscribe(data => {
    //     this.users=data;
    //   });
    // }


    // ngOnInit(){
    //   this.getUsers();
    // }
    experts: Expert[] = [];
    constructor(private _expertService: ExpertService) { }

    getExperts() {
        this._expertService.getAll().subscribe(data => {
            this.experts = data;
        });
    }

    ngOnInit() {
        this.getExperts();
    }
}


