import { Injectable } from '@angular/core';
import {Observable, of, throwError} from 'rxjs';
import {HttpClient, HttpHeaders, HttpErrorResponse} from '@angular/common/http'; 
import {MessageService} from '../messages/message.service';
import {Expert} from '../models/expert.model';
import {ExpertCreate} from '../models/expertCreate.model';
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
   
   private logSuccess(message: string){
    this._messageService.addSuccess(message);
  }
  private logError(message: string){
    this._messageService.addErrors(message);
  }  

   private handleError<T>(result?: T){
     return (errResp: HttpErrorResponse): Observable<T> => {
       if(errResp.error instanceof ErrorEvent){
        console.log('Client Side errResp', errResp.error.message);
       }
       else{
         console.log('Server Side errResp', errResp);
         if(errResp.status === 400){
          const errRespObject = errResp.error.errors;
          Object.keys(errRespObject as any).forEach(prop =>{
         let message = errRespObject[prop][0];
         this.logError(message);
          });
         }
         else if(errResp.status === 404 
          || errResp.status === 409){
            this.logError(errResp.error)
         }
        else {
          this.logError("Ooops, something went wrong, please try again later");
        }
          
       }    
       return of(result as T);
     }
   }

   getAll(): Observable<Expert[]>{
    return this._http.get<Expert[]>(this.apiUrl).pipe(
      catchError(this.handleError<Expert[]>([]))
    );
  }

  getSingle(id: string): Observable<Expert>{
    return this._http.get<Expert>(`${this.apiUrl}${id}`).pipe(
      catchError(this.handleError<Expert>())
    );
  }

  create(expert: ExpertCreate): Observable<Expert>{
    return this._http.post<Expert>(this.apiUrl, expert, this.httpOptions)
   .pipe(
     tap((newExpert: Expert) => this.logSuccess(`${newExpert.firstName} ${newExpert.lastName} was
     successfully added`)),
     catchError(this.handleError<Expert>())
   );
  }

  update(id: string, expert: Expert): Observable<Expert>{
      return this._http.put<Expert>(this.apiUrl + id, expert, this.httpOptions)
      .pipe(
        tap(_ => this.logSuccess(`${expert.firstName} ${expert.lastName} was
        successfully updated`)),
        catchError(this.handleError<Expert>())
      );
  }
 
  delete(id: string, expert: Expert): Observable<Expert>{
    return this._http.delete<Expert>(this.apiUrl + id, this.httpOptions)
    .pipe(
      tap(_ => this.logSuccess(`${expert.firstName} ${expert.lastName} was
      successfully deleted`)),
      catchError(this.handleError<Expert>())
    );
  }
}