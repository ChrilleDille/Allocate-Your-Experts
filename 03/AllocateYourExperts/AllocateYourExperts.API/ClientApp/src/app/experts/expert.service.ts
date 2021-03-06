import { Injectable } from '@angular/core';
import { Expert } from '../models/expert.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { throwError, Observable } from 'rxjs';
import { tap, catchError, map } from 'rxjs/operators';


@Injectable()
export class ExpertService {
    apiurl = 'api/experts';
    headers = new HttpHeaders().set('Content-Type', 'application/json').set('Accept', 'application/json');
    httpOptions = {
        headers: this.headers
    };

    constructor(private http: HttpClient) { }
    // private listExperts: Expert[] = [
    //     {

    //         id: "c94570ab-a13b-45f6-aec1-fc4994f7da17",
    //         firstName: "Christian",
    //         lastName: "Griffin",
    //         email: "chrille@somemail.com",
    //         gender: "Male"
    //     },
    //     {

    //         id: "e0a47365-6e76-4ed8-9504-7bee877a31d5",
    //         firstName: "Mirela",
    //         lastName: "Flummoic",
    //         email: "lela@somemail.com",
    //         gender: "Female"
    //     },
    //     {

    //         id: "28e9d5c5-623d-4d9d-94bc-c03891384daa",
    //         firstName: "Anton",
    //         lastName: "Andersson",
    //         email: "anton@somemail.com",
    //         gender: "Male"
    //     },
    //     {

    //         id: "fa1a4754-9dc6-4ecc-8cef-61f9624249bb",
    //         firstName: "Lena",
    //         lastName: "Tapper",
    //         email: "lena@somemail.com",
    //         gender: "Female"
    //     },
    //     {

    //         id: "3fe1f89f-ead1-4f4c-ba58-6d8cf5ae31be",
    //         firstName: "Håkan",
    //         lastName: "Fridolfsson",
    //         email: "hakan@somemail.com",
    //         gender: "Male"
    //     },
    //     {

    //         id: "91f29e45-000a-46c4-93ac-bf50d6bb6164",
    //         firstName: "Josefine",
    //         lastName: "Flygmaskin",
    //         email: "jossan@somemail.com",
    //         gender: "Female"
    //     },
    //     {

    //         id: "603212be-05a5-4ea3-956d-94b83438fd8a",
    //         firstName: "Henrik",
    //         lastName: "Holmqvist",
    //         email: "henke@somemail.com",
    //         gender: "Male"
    //     },
    //     {

    //         id: "a5794b8e-4dca-4b3b-8691-351c76740826",
    //         firstName: "Veronica",
    //         lastName: "Molin",
    //         email: "virre@somemail.com",
    //         gender: "Female"
    //     },
    //     {

    //         id: "0023e810-eb0a-4309-9b9a-55f4656cddb4",
    //         firstName: "Robin",
    //         lastName: "Törna",
    //         email: "robin@somemail.com",
    //         gender: "Male"
    //     },
    //     {

    //         id: "f066fcbb-ebd2-4018-a38c-56e5b02047bd",
    //         firstName: "Jonas",
    //         lastName: "Argman",
    //         email: "jonas@somemail.com",
    //         gender: "Male"
    //     }
    // ];

    private handleError(error: any) {
        console.error(error);
        return throwError(error);
    }

    getAll(): Observable<Expert[]> {
        return this.http.get<Expert[]>(this.apiurl).pipe(
            tap(data => console.log(data)),
            catchError(this.handleError)
        );
    }
}
