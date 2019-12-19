import {Injectable} from '@angular/core';
import {HttpErrorResponse} from '@angular/common/http';




@Injectable()
export class ErrorService{   
    private internalServerError: string = 'Ooops, something went wrong, please return later';

    listCreationErrors(errResp: HttpErrorResponse, list: any[]){
        if(errResp.status === 409){
          list.push(errResp.error);
        }
        else if(errResp.status === 400){
           const errorObject = errResp.error.errors;
           Object.keys(errorObject as any).forEach(prop =>{
            let message = errorObject[prop][0];
            list.push(message);
           });
        }
        else {
          alert(this.internalServerError); 
        }
      }

    listGetErrors(errResp: HttpErrorResponse){
      if(errResp.status === 500){
        alert(this.internalServerError);
      }
      alert(errResp.error);
    }

    
   
}