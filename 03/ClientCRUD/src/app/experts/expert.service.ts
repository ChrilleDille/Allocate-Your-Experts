import { Injectable } from '@angular/core';
import { Expert } from '../models/expert.model';
import {ExpertCreate} from '../models/expertCreate.model';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { throwError, Observable } from 'rxjs';
import { tap, catchError, map } from 'rxjs/operators';


@Injectable()
export class ExpertService {
  apiurl = 'http://localhost:57856/api/experts/';
  headers = new HttpHeaders().set('Content-Type', 'application/json').set('Accept', 'application/json');
  httpOptions = {
    headers: this.headers
  };

  constructor(private http: HttpClient) { }

  private handleError(errResp: HttpErrorResponse) {
   if(errResp.error instanceof ErrorEvent){
      console.log('Client Side Error:', errResp.error.message);
   }
   else{
     console.log('Server Side Error:', errResp);
   }
   return throwError(errResp);
  }

  getAll(): Observable<Expert[]> {
    return this.http.get<Expert[]>(this.apiurl).pipe(
      catchError(this.handleError));
    }

    getSingle(id: string): Observable<Expert>{
      return this.http.get<Expert>(this.apiurl + id).pipe(
        catchError(this.handleError));
    }

    create(expert: ExpertCreate): Observable<Expert>{
      return this.http.post<Expert>(this.apiurl, expert, this.httpOptions).pipe(
        catchError(this.handleError));
    }

    update(id: string, expert: ExpertCreate): Observable<Expert>{
      return this.http.put<Expert>(this.apiurl + id, expert, this.httpOptions).pipe(
        catchError(this.handleError));
    }

    delete(id: string): Observable<Expert>{
      return this.http.delete<Expert>(this.apiurl + id, this.httpOptions).pipe(
        catchError(this.handleError));
    }
}