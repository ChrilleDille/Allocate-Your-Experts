import { Injectable } from '@angular/core';
import {MessageService} from './message.service';
import {Observable, of, throwError} from 'rxjs';
import {HttpClient, HttpHeaders, HttpErrorResponse} from '@angular/common/http'; 
import {Expert} from './models/expert.model';
import {catchError, map, tap} from 'rxjs/operators';

@Injectable()
export class ExpertService {
 constructor(private _messageService: MessageService,
  private _http: HttpClient) { }
 
 apiUrl = 'http://localhost:57856/api/experts/';
 headers = new HttpHeaders().set('Content-Type', 'application/json').set('Accept', 'application/json');
 httpOptions = {
   headers: this.headers
 };

 private handleError<T>(result?: T){
   return (error: HttpErrorResponse): Observable<T> => {
     if(error.error instanceof ErrorEvent){
      console.log('Client Side Error', error.error.message);
     }
     else{
       console.log('Server Side Error', error);
       switch(error.status) { 
        case 404: { 
           this.log(error.error);
           break; 
        } 
        case 400: { 
           this.log('400')
           break; 
        } 
        default: { 
           this.log('OOOOOOOOOpss!!!!');
           break; 
        } 
     } 
        
     }    
     return of(result as T);
   }
 }

 private log(message: string){
   this._messageService.add(`ExpertService: ${message}`);
 }

 getAll(): Observable<Expert[]>{
   this._messageService.add('ExpertService: fetched experts');
   return this._http.get<Expert[]>(this.apiUrl).pipe(
     tap(_ => this.log('fetched experts')),
     catchError(this.handleError<Expert[]>([]))
   );
 }

}

